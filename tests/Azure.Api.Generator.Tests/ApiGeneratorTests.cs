using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AwesomeAssertions;
using Azure.Api.Generator.CodeGeneration;
using Microsoft.CodeAnalysis;
using Azure.Api.Generator.Tests.Utils;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using Xunit;

namespace Azure.Api.Generator.Tests;

public class ApiGeneratorTests
{
    private CancellationToken Cancellation => TestContext.Current.CancellationToken;
    
    [Fact]
    public void GivenAnOpenAPISpec_WhenGeneratingAPI_ExpectedClassesShouldHaveBeenGenerated()
    {
        var generator = new ApiGenerator();

        GeneratorDriver driver = CSharpGeneratorDriver.Create(generator);

        driver = driver.AddAdditionalTexts(
            [
                new TestAdditionalFile("Microsoft.FileStorage.ApiSpecs/stable/2025-11-05/file.json")
            ]
        );

        var compilation = CSharpCompilation.Create(nameof(ApiGeneratorTests));
        driver.RunGeneratorsAndUpdateCompilation(compilation, out var newCompilation, out var diagnostics, TestContext.Current.CancellationToken);

        // Operation handler stubs should be generated with a warning
        diagnostics.Should().AllSatisfy(diagnostic =>
        {
            diagnostic.Severity.Should().Be(DiagnosticSeverity.Warning);
            diagnostic.Id.Should().Be("AF1001");
        }); 

        var generatedFiles = newCompilation.SyntaxTrees
            .Select(t => Path.GetFileName(t.FilePath))
            .ToArray();
        
        generatedFiles.Should().HaveCountGreaterThan(0);
    }

    [Fact]
    public void GivenAImplementedOperation_WhenGeneratingAPI_NoOperationHandlerStubsShouldBeGenerated()
    {
        var generator = new ApiGenerator();

        GeneratorDriver driver = CSharpGeneratorDriver.Create(generator);

        driver = driver.AddAdditionalTexts(
            [
                new InMemoryAdditionalText("openapi.json",
                    """
                      {
                        "swagger": "2.0",
                        "paths": {
                        "/foo": {
                            "put": {
                            "operationId": "Service_SetProperties",
                            "description": "Sets properties for a storage account's File service endpoint, including properties for Storage Analytics metrics and CORS (Cross-Origin Resource Sharing) rules.",
                            "parameters": [
                                {
                                "name": "StorageServiceProperties",
                                "in": "body",
                                "description": "The StorageService properties.",
                                "required": true,
                                "schema": {
                                  "description": "Storage service properties.",
                                  "type": "object",
                                  "properties": {
                                    "HourMetrics": {
                                      "description": "A summary of request statistics grouped by API in hourly aggregates for files.",
                                      "type": "string"
                                    }
                                  }
                                }
                            }],
                            "responses": {
                              "202": {
                                "description": "Success (Accepted)"
                              }
                            }
                          }
                        }
                      }
                    }
                    """)
            ]
        );

        var compilation = CSharpCompilation.Create(nameof(ApiGeneratorTests),
            options: new CSharpCompilationOptions(outputKind: OutputKind.DynamicallyLinkedLibrary));

        var implementedOperationSourceCode = CSharpSyntaxTree.ParseText(SourceText.From(
            """
            namespace Foo.ServiceSetProperties
            {
                internal partial class Operation
                {
                    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken)
                    {
                        throw new NotImplementedException();
                    }
                }
            }
            """
        ), cancellationToken: Cancellation);
        implementedOperationSourceCode.GetDiagnostics(Cancellation).Should().BeEmpty();
        compilation = compilation.AddSyntaxTrees(implementedOperationSourceCode);

        driver.RunGeneratorsAndUpdateCompilation(compilation, out var newCompilation, out var diagnostics,
            Cancellation);

        diagnostics.Should().BeEmpty();

        newCompilation.SyntaxTrees.Should().HaveCountGreaterThan(0);
        var operationType = newCompilation.GetSymbolsWithName("Operation", cancellationToken: Cancellation)
            .OfType<INamedTypeSymbol>()
            .Where(symbol => symbol.ContainingNamespace.ToDisplayString() == "Foo.ServiceSetProperties")
            .Should().HaveCount(1).And.Subject.First();
        var handleAsyncSymbol = operationType.GetMembers("HandleAsync")
            .OfType<IMethodSymbol>()
            .Should().HaveCount(1, "there should be a single implementation of HandleAsync").And.Subject.First();

        handleAsyncSymbol.Parameters.Should().HaveCount(2);
        handleAsyncSymbol.Parameters[0].Type.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat).Should()
            .Be("Request");
        handleAsyncSymbol.Parameters[1].Type.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat).Should()
            .Be("CancellationToken");
        handleAsyncSymbol.PartialImplementationPart.Should().NotBeNull();

        var generatedFiles = newCompilation.SyntaxTrees
            .Select(t => Path.GetFileName(t.FilePath))
            .ToArray();

        generatedFiles.Should().HaveCountGreaterThan(0);
    }
}
