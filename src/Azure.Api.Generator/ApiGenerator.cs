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
using Microsoft.OpenApi.Writers;

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
        context.RegisterSourceOutput(openapiDocumentProvider, WithExceptionReporting<OpenApiDocument>(GenerateCode));
        
        // Get global options
        var globalOptions =
            context.AnalyzerConfigOptionsProvider.Select((optionsProvider, token) =>
                new SourceGeneratorHelpers.GlobalOptions(
                    fallbackVocabulary: Corvus.Json.CodeGeneration.Draft4.VocabularyAnalyser.DefaultVocabulary,
                    optionalAsNullable: true,
                    useOptionalNameHeuristics: true,
                    alwaysAssertFormat: true,
                    ImmutableArray<string>.Empty));

        var typeSpec = openapiDocumentProvider
            .Select((document, _) =>
                document.Paths.SelectMany(path => ExtractTypeSpecifications(path.Key, path.Value))
                    .ToList());
        
        var generationSpecifications = typeSpec.SelectMany((enumerable, _) => 
            enumerable.Select(parameterSpec =>
                new SourceGeneratorHelpers.GenerationSpecification(
                    ns: parameterSpec.Namespace, 
                    typeName: parameterSpec.Name, 
                    location: parameterSpec.Schema.Path,
                    rebaseToRootPath: false))
                .ToList());

        var documentResolver = typeSpec
            .Select((enumerable, _) =>
                enumerable.Select(AdditionalText (arg) => arg.Schema))
            .Select((texts, token) => SourceGeneratorHelpers.BuildDocumentResolver([..texts], token));

        var generationContext = 
            documentResolver.Combine(globalOptions)
                .Select((r, c) => 
                    new SourceGeneratorHelpers.GenerationContext(r.Left, r.Right));
            
        var typesToGenerate = 
            generationSpecifications.Collect()
                .Combine(generationContext).Select((c, t) => 
                    new SourceGeneratorHelpers.TypesToGenerate(c.Left, c.Right));

        context.RegisterSourceOutput(typesToGenerate, GenerateCode);
    }

    private static IEnumerable<TypeSpecification> ExtractTypeSpecifications(string pathExpression, OpenApiPathItem pathItem)
    {
        var entityType = pathExpression.ToPascalCase();

        foreach (var parameter in pathItem.Parameters)
        {
            var parameterTypeSpecification = new TypeSpecification(
                parameter.Name.ToPascalCase() + parameter.In.ToString().ToPascalCase(),
                schema: new InMemoryAdditionalText(
                    $"/{entityType}-{parameter.Name}-{parameter.In}.json",
                    parameter.Schema.SerializeToJson()),
                @namespace: entityType
            );
            yield return parameterTypeSpecification;
        }

        foreach (var openApiOperation in pathItem.Operations)
        {
            var type = openApiOperation.Key;
            var operation = openApiOperation.Value;
            var operationId = ((string?)operation.OperationId ?? type.ToString()).ToPascalCase();
            foreach (var parameter in operation.Parameters)
            {
                var parameterTypeSpecification = new TypeSpecification(
                    parameter.Name.ToPascalCase() + parameter.In.ToString().ToPascalCase(),
                    schema: new InMemoryAdditionalText(
                        $"/{entityType}-{operationId}-{parameter.Name}-{parameter.In}.json",
                        parameter.Schema.SerializeToJson()),
                    @namespace: $"{entityType}.{operationId}"
                );
                yield return parameterTypeSpecification;
            } 
        }
    }
    
    private void GenerateCode(SourceProductionContext context, OpenApiDocument openApiDoc)
    {
        foreach (var path in openApiDoc.Paths)
        {
            foreach (var operation in path.Value.Operations)
            {
                var operationName = operation.Value.OperationId.ToPascalCase();
                var source =
                    $$"""
                      namespace Endpoints;

                      internal partial class {{operationName}}
                      {

                      }
                      """;
                context.AddSource($"{operationName}.g.cs", ParseCSharpCode(source));
                
            }
        }
    }

    private static void GenerateCode(SourceProductionContext context, SourceGeneratorHelpers.TypesToGenerate generationSource)
    {
        SourceGeneratorHelpers.GenerateCode(context, generationSource, VocabularyRegistry);
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