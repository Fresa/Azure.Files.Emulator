using Corvus.Json;

namespace Azure.Files.Emulator.ShareNameDirectoryFileNameRestypeSymboliclink.FileCreateSymbolicLink;
internal abstract partial class Response
{
    internal sealed class Created201 : Response
    {
        internal Corvus.Json.JsonAny ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal Azure.Files.Emulator.ShareNameDirectoryFileNameRestypeSymboliclink.FileCreateSymbolicLink.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
