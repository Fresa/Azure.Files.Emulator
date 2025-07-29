using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;

namespace Azure.Api.Generator;

internal sealed class SourceCode(string fileName, string code)
{
    internal void AddTo(SourceProductionContext context)
    {
        context.AddSource(fileName, ParseCSharpCode(code));
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