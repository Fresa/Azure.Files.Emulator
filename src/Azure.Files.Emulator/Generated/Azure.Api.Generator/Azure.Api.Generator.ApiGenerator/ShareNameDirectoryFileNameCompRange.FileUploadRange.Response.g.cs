using Corvus.Json;

namespace Azure.Files.Emulator.ShareNameDirectoryFileNameCompRange.FileUploadRange;
internal abstract partial class Response
{
    internal sealed class Created201 : Response
    {
        internal Corvus.Json.JsonAny ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal Azure.Files.Emulator.ShareNameDirectoryFileNameCompRange.FileUploadRange.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
