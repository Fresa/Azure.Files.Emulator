using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;

namespace Azure.Api.Generator;

internal sealed class SourceCode(string fileName, string code)
{
    // Rider (and possibly other IDEs) aren't dealing with directories properly,
    // where source generated code is not displayed or has file hint names truncated,
    // so we deal with this by only allowing a single level directory hierarchy
    // Example:
    // this/is/a/deep/hierarchy/file.cs
    // becomes:
    // this_is_a_deep_hierarchy/file.cs
    // https://youtrack.jetbrains.com/issue/RIDER-130837
    private readonly string _fileName = fileName.LastIndexOf('/') == -1
        ? fileName
        : fileName[..fileName.LastIndexOf('/')].Replace('/', '.') + fileName[fileName.LastIndexOf('/')..];

    internal void AddTo(SourceProductionContext context)
    {
        context.AddSource(_fileName, ParseCSharpCode(code));
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
}