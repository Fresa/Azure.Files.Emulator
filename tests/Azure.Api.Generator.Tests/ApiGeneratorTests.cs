using System.IO;
using System.Linq;
using AwesomeAssertions;
using Microsoft.CodeAnalysis;
using Azure.Api.Generator.Tests.Utils;
using Microsoft.CodeAnalysis.CSharp;
using Xunit;

namespace Azure.Api.Generator.Tests;

public class ApiGeneratorTests
{
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

        diagnostics.Should().BeEmpty();
        var generatedFiles = newCompilation.SyntaxTrees
            .Select(t => Path.GetFileName(t.FilePath))
            .ToArray();
        
        generatedFiles.Should().HaveCountGreaterThan(0);
    }
}