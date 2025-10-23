using Corvus.Json;

namespace Azure.Files.Emulator.ShareNameDirectoryRestypeDirectory.DirectoryCreate;
internal abstract partial class Response
{
    internal sealed class Created201 : Response
    {
        internal Corvus.Json.JsonAny ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal Azure.Files.Emulator.ShareNameDirectoryRestypeDirectory.DirectoryCreate.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
