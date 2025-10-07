using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace ShareNameDirectoryFileNameCompRangeFromURL.FileUploadRangeFromURL;
internal abstract partial class Response
{
    internal sealed class Created201 : Response
    {
        internal Corvus.Json.JsonAny ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal ShareNameDirectoryFileNameCompRangeFromURL.FileUploadRangeFromURL.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
