using System;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Azure.Api.Generator.Extensions;
using Corvus.Json;
using Corvus.Json.CodeGeneration;
using Corvus.Json.SourceGeneratorTools;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using Microsoft.OpenApi.Extensions;
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
        
        context.RegisterSourceOutput(provider, WithExceptionReporting<ImmutableArray<OpenApiDocument>>(GenerateCode));
        
        // Get global options
        var globalOptions =
            context.AnalyzerConfigOptionsProvider.Select((optionsProvider, token) =>
                new SourceGeneratorHelpers.GlobalOptions(
                    fallbackVocabulary: Corvus.Json.CodeGeneration.Draft4.VocabularyAnalyser.DefaultVocabulary,
                    optionalAsNullable: true,
                    useOptionalNameHeuristics: true,
                    alwaysAssertFormat: true,
                    ImmutableArray<string>.Empty));

        var parameterReferences = provider.Select((array, token) => array.First())
            .Select((document, token) =>
                document.Paths.SelectMany((item, i) =>
                        item.Value.Parameters.Select(parameter =>
                        {
                            var r = parameter.Reference;
                            using var sq = new StringWriter();
                            var oajw = new OpenApiJsonWriter(sq);
                            parameter.Schema.SerializeAsV2WithoutReference(
                                oajw);
                            return new
                            {
                                Parameter = parameter, Schema = sq.GetStringBuilder().ToString(),
                                Location = $"//tmp/{i}{parameter.Name}{parameter.In}.json"
                            };
                        }))
                    .ToList());
        
        var generationSpecifications = parameterReferences.SelectMany((enumerable, token) => 
            enumerable.Select(s =>
                new SourceGeneratorHelpers.GenerationSpecification(
                    ns: "test", 
                    typeName: s.Parameter.Name+s.Parameter.In, 
                    location: s.Location,
                    rebaseToRootPath: false))
                .ToList());
        
        var documentResolver = parameterReferences
            .Select((enumerable, token) => 
                enumerable.Select(AdditionalText (arg) => 
                    new InMemoryAdditionalText(arg.Location, arg.Schema)))
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

    private void GenerateCode(SourceProductionContext context, ImmutableArray<OpenApiDocument> openApiDocuments)
    {
        var openApiDoc = openApiDocuments.FirstOrDefault();
        if (openApiDoc is null)
            return;
        
        foreach (var path in openApiDoc.Paths)
        {
            foreach (var operation in path.Value.Operations)
            {
                var operationName = operation.Value.OperationId.ToPascalCase('_');
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