using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Azure.Api.Generator.CodeGeneration;
using Azure.Api.Generator.Extensions;
using Azure.Api.Generator.OpenApi;
using Corvus.Json;
using Corvus.Json.CodeGeneration;
using Corvus.Json.CodeGeneration.CSharp;
using Corvus.Json.SourceGeneratorTools;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers;

namespace Azure.Api.Generator;

[Generator]
public sealed class ApiGenerator : IIncrementalGenerator
{
    private static readonly IDocumentResolver MetaSchemaResolver = SourceGeneratorHelpers.CreateMetaSchemaResolver();
    private static readonly VocabularyRegistry VocabularyRegistry = SourceGeneratorHelpers.CreateVocabularyRegistry(MetaSchemaResolver);

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        // Debugger.Launch();

        var provider = context.AdditionalTextsProvider
            .Where(additionalText => Path.GetFileName(additionalText.Path).EndsWith(".json"))
            .Select((text, token) => new OpenApiStreamReader().Read(text.AsStream(), out _))
            .Collect();
        
        var openapiDocumentProvider = provider.Select((array, _) => array.First());
        var projectDir = context.AnalyzerConfigOptionsProvider.Select((config, _) =>
            config.GlobalOptions
                .TryGetValue("build_property.ProjectDir", out var projectDir)
                ? projectDir
                : null
        );
        
        // Get global options
        var globalOptions =
            context.AnalyzerConfigOptionsProvider.Select((optionsProvider, token) =>
                new SourceGeneratorHelpers.GlobalOptions(
                    fallbackVocabulary: Corvus.Json.CodeGeneration.Draft4.VocabularyAnalyser.DefaultVocabulary,
                    optionalAsNullable: true,
                    useOptionalNameHeuristics: true,
                    alwaysAssertFormat: true,
                    ImmutableArray<string>.Empty));

        var openApiProvider = globalOptions
            .Combine(openapiDocumentProvider)
            .Combine(context.CompilationProvider)
            .Combine(projectDir)
            .Select((tuple, _) => (
                Options: tuple.Left.Left.Left,
                OpenApiDocument: tuple.Left.Left.Right,
                Compilation: tuple.Left.Right,
                ProjectDir: tuple.Right
            ));

        context.RegisterSourceOutput(openApiProvider,
            WithExceptionReporting<(SourceGeneratorHelpers.GlobalOptions, OpenApiDocument, Compilation, string?)>(GenerateCode));
    }

    private static void GenerateCode(SourceProductionContext context, (SourceGeneratorHelpers.GlobalOptions Options, OpenApiDocument OpenApiDocument, Compilation Compilation, string? ProjectDir) generatorContext)
    {
        var openApi = generatorContext.OpenApiDocument;
        var globalOptions = generatorContext.Options;
        var compilation = generatorContext.Compilation;
        var projectDir = generatorContext.ProjectDir;
        var endpointGenerator = new EndpointGenerator(compilation);
        foreach (var path in openApi.Paths)
        {
            var pathExpression = path.Key;
            var pathItem = path.Value;
            var entityType = pathExpression.ToPascalCase();
            var parameterGenerators = new Dictionary<string, ParameterGenerator>();
            foreach (var parameter in pathItem.Parameters)
            {
                var schema = new InMemoryAdditionalText(
                    $"/{entityType}.{parameter.GetTypeDeclarationIdentifier()}.json",
                        parameter.Schema.SerializeToJson());
                
                var generationSpecification = new SourceGeneratorHelpers.GenerationSpecification(
                    ns: entityType,
                    typeName: parameter.GetTypeDeclarationIdentifier(),
                    location: schema.Path,
                    rebaseToRootPath: false);
                var typeDeclaration = GenerateCode(context, generationSpecification, schema, globalOptions);
                parameterGenerators[parameter.Name] = new ParameterGenerator(typeDeclaration, parameter);
            }

            foreach (var openApiOperation in path.Value.Operations)
            {
                var operationType = openApiOperation.Key;
                var operation = openApiOperation.Value;
                var operationId = ((string?)operation.OperationId ?? operationType.ToString()).ToPascalCase();
                var @namespace = $"{entityType}.{operationId}";
                var directory = @namespace.Replace('.', '/');
                
                foreach (var parameter in operation.Parameters)
                {
                    var schema = new InMemoryAdditionalText(
                        $"/{@namespace}.{parameter.GetTypeDeclarationIdentifier()}.json",
                        parameter.Schema.SerializeToJson());
                    
                    var generationSpecification = new SourceGeneratorHelpers.GenerationSpecification(
                        ns: @namespace,
                        typeName: parameter.GetTypeDeclarationIdentifier(),
                        location: schema.Path,
                        rebaseToRootPath: false);

                    var typeDeclaration = GenerateCode(context, generationSpecification, schema, globalOptions);
                    parameterGenerators[parameter.Name] = new ParameterGenerator(typeDeclaration, parameter);
                }

                var requestSource =
                    $$"""
                        using Azure.Files.Emulator.Http;
                        using Corvus.Json;
                        
                        namespace {{@namespace}};
                        
                        internal partial class Request
                        {
                            {{parameterGenerators.Values.Aggregate(new StringBuilder(),(builder, generator) => 
                                builder.AppendLine(generator.GenerateRequestProperty()))}}

                            public static Request Bind(HttpRequest request)
                            {
                                return new Request
                                {
                                    {{parameterGenerators.Values.Aggregate(new StringBuilder(),(builder, generator) => 
                                        builder.AppendLine(generator.GenerateRequestBindingDirective()))}}
                                };
                            }
                        }
                      """;
                var requestSourceCode = new SourceCode(
                    $"{directory}/Request.g.cs",
                    requestSource);
                requestSourceCode.AddTo(context);
                
                var responseSource =
                    $$"""
                        using Azure.Files.Emulator.Http;
                        using Corvus.Json;
                        
                        namespace {{@namespace}};
                        
                        internal partial class Response
                        {
                        }
                      """;
                var responseSourceCode = new SourceCode(
                    $"{directory}/Response.g.cs",
                    responseSource);
                responseSourceCode.AddTo(context);

                endpointGenerator
                    .Generate(@namespace, pathExpression, operationId)
                    .AddTo(context);
            }
        }

        if (endpointGenerator.TryGenerateMissingHandlers(out var missingHandlers))
        {
            foreach (var missingHandler in missingHandlers)
            {
                missingHandler.SourceCode.AddTo(context);
                context.ReportDiagnostic(missingHandler.Diagnostic);
            }
        }
    }

    private static readonly DiagnosticDescriptor Crv1001ErrorGeneratingCSharpCode =
        new(
            id: "CRV1001",
            title: "JSON Schema Type Generator Error",
            messageFormat: "Error generating C# code: {0}",
            category: "JsonSchemaCodeGenerator",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);

    private static TypeDeclaration GenerateCode(SourceProductionContext context,
        SourceGeneratorHelpers.GenerationSpecification specification,
        AdditionalText schema,
        SourceGeneratorHelpers.GlobalOptions globalOptions)
    {
        var generationContext = new SourceGeneratorHelpers.GenerationContext(SourceGeneratorHelpers.BuildDocumentResolver([schema], context.CancellationToken), globalOptions);
        var typeDeclarations = GenerateCode(context, new SourceGeneratorHelpers.TypesToGenerate(
            [specification], generationContext), VocabularyRegistry);
        return typeDeclarations.Single();
    }

    private static List<TypeDeclaration> GenerateCode(SourceProductionContext context, SourceGeneratorHelpers.TypesToGenerate typesToGenerate, VocabularyRegistry vocabularyRegistry)
    {
        if (typesToGenerate.GenerationSpecifications.Length == 0)
        {
            // Nothing to generate
            return [];
        }

        List<TypeDeclaration> typeDeclarationsToGenerate = [];
        List<CSharpLanguageProvider.NamedType> namedTypes = [];
        JsonSchemaTypeBuilder typeBuilder = new(typesToGenerate.DocumentResolver, vocabularyRegistry);

        string? defaultNamespace = null;

        foreach (SourceGeneratorHelpers.GenerationSpecification spec in typesToGenerate.GenerationSpecifications)
        {
            if (context.CancellationToken.IsCancellationRequested)
            {
                return [];
            }

            string schemaFile = spec.Location;
            JsonReference reference = new(schemaFile);
            TypeDeclaration rootType;
            try
            {
                rootType = typeBuilder.AddTypeDeclarations(reference, typesToGenerate.FallbackVocabulary, spec.RebaseToRootPath, context.CancellationToken);
            }
            catch (Exception ex)
            {
                context.ReportDiagnostic(
                    Diagnostic.Create(
                        Crv1001ErrorGeneratingCSharpCode,
                        Location.None,
                        reference,
                        ex.Message));

                return [];
            }
            
            typeDeclarationsToGenerate.Add(rootType);

            defaultNamespace ??= spec.Namespace;

            // Only add the named type if the spec.TypeName is not null or empty.
            if (!string.IsNullOrEmpty(spec.TypeName))
            {
                namedTypes.Add(
                    new CSharpLanguageProvider.NamedType(
                        rootType.ReducedTypeDeclaration().ReducedType.LocatedSchema.Location,
                        spec.TypeName,
                        spec.Namespace,
                        spec.Accessibility));
            }
        }

        CSharpLanguageProvider.Options options = new(
            defaultNamespace ?? "GeneratedTypes",
            [.. namedTypes],
            useOptionalNameHeuristics: typesToGenerate.UseOptionalNameHeuristics,
            alwaysAssertFormat: typesToGenerate.AlwaysAssertFormat,
            optionalAsNullable: typesToGenerate.OptionalAsNullable,
            disabledNamingHeuristics: [.. typesToGenerate.DisabledNamingHeuristics],
            fileExtension: ".g.cs",
            defaultAccessibility: typesToGenerate.DefaultAccessibility);

        var languageProvider = CSharpLanguageProvider.DefaultWithOptions(options);

        IReadOnlyCollection<GeneratedCodeFile> generatedCode;

        try
        {
            generatedCode =
                typeBuilder.GenerateCodeUsing(
                    languageProvider,
                    context.CancellationToken,
                    typeDeclarationsToGenerate);
        }
        catch (Exception ex)
        {
            context.ReportDiagnostic(
                Diagnostic.Create(
                    Crv1001ErrorGeneratingCSharpCode,
                    Location.None,
                    ex.Message));

            return [];
        }

        foreach (GeneratedCodeFile codeFile in generatedCode)
        {
            if (!context.CancellationToken.IsCancellationRequested)
            {
                context.AddSource(codeFile.TypeDeclaration.DotnetNamespace().Replace('.', '/') + $"/{codeFile.FileName}", SourceText.From(codeFile.FileContent, Encoding.UTF8));
            }
        }

        return typeDeclarationsToGenerate;
    }
    
    private static Action<SourceProductionContext, T> WithExceptionReporting<T>(
        Action<SourceProductionContext, T> handler) =>
        (productionContext, input) =>
        {
            try
            {
                handler.Invoke(productionContext, input);
            }
            catch (Exception e)
            {
                var stackTrace = new StackTrace(e, true);
                StackFrame? firstFrameWithLineNumber = null;
                for (var i = 0; i < stackTrace.FrameCount; i++)
                {
                    var frame = stackTrace.GetFrame(i);
                    if (frame.GetFileLineNumber() != 0)
                    {
                        firstFrameWithLineNumber = frame;
                        break;
                    }
                }

                var firstStackTraceLocation = firstFrameWithLineNumber == null ?
                    Location.None :
                    Location.Create(
                        firstFrameWithLineNumber.GetFileName(),
                        new TextSpan(),
                        new LinePositionSpan(
                            new LinePosition(
                                firstFrameWithLineNumber.GetFileLineNumber(),
                                firstFrameWithLineNumber.GetFileColumnNumber()),
                            new LinePosition(
                                firstFrameWithLineNumber.GetFileLineNumber(),
                                firstFrameWithLineNumber.GetFileColumnNumber() + 1)));

                productionContext.ReportDiagnostic(Diagnostic.Create(
                    UnhandledException,
                    location: firstStackTraceLocation,
                    // Only single line https://github.com/dotnet/roslyn/issues/1455
                    messageArgs: [e.ToString().Replace("\r\n", " |").Replace("\n", " |")]));
            }
        };
    
    private static readonly DiagnosticDescriptor UnhandledException =
        new(
            id: "AF0001",
            title: "Unhandled error",
            // Only single line https://github.com/dotnet/roslyn/issues/1455
            messageFormat: "{0}",
            category: "Compiler",
            defaultSeverity: DiagnosticSeverity.Error,
            isEnabledByDefault: true,
            // Doesn't work
            description: null,
            customTags: WellKnownDiagnosticTags.AnalyzerException);
}