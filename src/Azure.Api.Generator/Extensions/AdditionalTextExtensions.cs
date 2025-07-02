using System.IO;
using System.Text;
using Microsoft.CodeAnalysis;

namespace Azure.Api.Generator.Extensions;

internal static class AdditionalTextExtensions
{
    internal static Stream AsStream(this AdditionalText text)
    {
        var content = text.GetText();
        if (content is null)
        {
            return Stream.Null;
        }
        var stream = new MemoryStream();

        using (var writer = new StreamWriter(stream, Encoding.UTF8, 1024, true))
        {
            content.Write(writer);    
        }
        
        stream.Position = 0;
        return stream;
    }
}