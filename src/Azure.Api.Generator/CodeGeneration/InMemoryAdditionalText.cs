using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Azure.Api.Generator.CodeGeneration;

public class InMemoryAdditionalText(string path, string content) : AdditionalText
{
    public override SourceText? GetText(CancellationToken cancellationToken = new CancellationToken())
    {
        return SourceText.From(content);
    }

    public override string Path { get; } = path;
}