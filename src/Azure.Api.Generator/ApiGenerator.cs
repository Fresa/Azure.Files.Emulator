using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Azure.Api.Generator.CodeGeneration;
using Azure.Api.Generator.Extensions;
using Corvus.Json;
using Corvus.Json.CodeGeneration;
using Corvus.Json.SourceGeneratorTools;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
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
        
        // Get global options
        var globalOptions =
            context.AnalyzerConfigOptionsProvider.Select((optionsProvider, token) =>
                new SourceGeneratorHelpers.GlobalOptions(
                    fallbackVocabulary: Corvus.Json.CodeGeneration.Draft4.VocabularyAnalyser.DefaultVocabulary,
                    optionalAsNullable: true,
                    useOptionalNameHeuristics: true,
                    alwaysAssertFormat: true,
                    ImmutableArray<string>.Empty));

        var openApiProvider = globalOptions.Combine(openapiDocumentProvider);
     
        context.RegisterSourceOutput(openApiProvider, WithExceptionReporting<(SourceGeneratorHelpers.GlobalOptions, OpenApiDocument)>(GenerateCode));
    }

    private static void GenerateCode(SourceProductionContext context, (SourceGeneratorHelpers.GlobalOptions Options, OpenApiDocument OpenApiDocument) generatorContext)
    {
        var openApi = generatorContext.OpenApiDocument;
        var globalOptions = generatorContext.Options;
        var schemas = new List<InMemoryAdditionalText>();
        var generationSpecifications = new List<SourceGeneratorHelpers.GenerationSpecification>();
        foreach (var path in openApi.Paths)
        {
            var pathExpression = path.Key;
            var pathItem = path.Value;
            var entityType = pathExpression.ToPascalCase();
            var parameterGenerators = new List<ParameterGenerator>();
            foreach (var parameter in pathItem.Parameters)
            {
                var parameterGenerator = new ParameterGenerator(entityType, parameter);
                var schema = new InMemoryAdditionalText($"/{parameterGenerator.FullyQualifiedTypeDeclarationIdentifier}.json",
                        parameter.Schema.SerializeToJson());
                schemas.Add(schema);
                
                var generationSpecification = new SourceGeneratorHelpers.GenerationSpecification(
                    ns: entityType,
                    typeName: parameterGenerator.TypeDeclarationIdentifier,
                    location: schema.Path,
                    rebaseToRootPath: false);
                generationSpecifications.Add(generationSpecification);
                parameterGenerators.Add(parameterGenerator);
            }

            foreach (var openApiOperation in path.Value.Operations)
            {
                var type = openApiOperation.Key;
                var operation = openApiOperation.Value;
                var operationId = ((string?)operation.OperationId ?? type.ToString()).ToPascalCase();
                var @namespace = $"{entityType}.{operationId}";
                
                foreach (var parameter in operation.Parameters)
                {
                    var parameterGenerator = new ParameterGenerator(@namespace, parameter);
                    var schema = new InMemoryAdditionalText(
                        $"/{parameterGenerator.FullyQualifiedTypeDeclarationIdentifier}.json",
                        parameter.Schema.SerializeToJson());
                    schemas.Add(schema);
                    
                    var generationSpecification = new SourceGeneratorHelpers.GenerationSpecification(
                        ns: @namespace,
                        typeName: parameterGenerator.TypeDeclarationIdentifier,
                        location: schema.Path,
                        rebaseToRootPath: false);
                    generationSpecifications.Add(generationSpecification);
                    parameterGenerators.Add(parameterGenerator);
                }

                var requestSource =
                    $$"""
                        namespace {{@namespace}};

                        internal partial class Request
                        {
                            {{parameterGenerators.Aggregate(new StringBuilder(),(builder, generator) => 
                                builder.AppendLine(generator.GenerateRequestProperty()))}}

                            public static Request Bind(HttpRequest request)
                            {
                                return new Request
                                {
                                    {{parameterGenerators.Aggregate(new StringBuilder(),(builder, generator) => 
                                        builder.AppendLine(generator.GenerateRequestBindingDirective()))}}
                                };
                            }
                        }
                      """;
                context.AddSource($"{operationId}/Request.g.cs", ParseCSharpCode(requestSource));
                
                var endpointSource =
                    $$"""
                      namespace {{@namespace}};

                      internal partial class {{operationId}}
                      {

                      }
                      """;
                context.AddSource($"{operationId}/{operationId}.g.cs", ParseCSharpCode(endpointSource));
            }
        }
        
        var generationContext = new SourceGeneratorHelpers.GenerationContext(SourceGeneratorHelpers.BuildDocumentResolver([..schemas], context.CancellationToken), globalOptions);
        SourceGeneratorHelpers.GenerateCode(context, new SourceGeneratorHelpers.TypesToGenerate(
            [..generationSpecifications], generationContext), VocabularyRegistry);
    }

    private static SourceText ParseCSharpCode(string code, bool normalize = true)
    {
        var compilationUnit = SyntaxFactory
            .ParseCompilationUnit(code, options: new CSharpParseOptions());
        if (normalize)
        {
            compilationUnit = compilationUnit.NormalizeWhitespace();
        }
        return compilationUnit.WithTrailingTrivia(SyntaxFactory.CarriageReturnLineFeed)
            .GetText(Encoding.UTF8);
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