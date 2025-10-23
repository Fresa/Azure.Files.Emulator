using Corvus.Json;

namespace Azure.Files.Emulator.ShareNameDirectoryRestypeDirectoryCompMetadata.DirectorySetMetadata;
internal abstract partial class Response
{
    internal sealed class OK200 : Response
    {
        internal Corvus.Json.JsonAny ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal Azure.Files.Emulator.ShareNameDirectoryRestypeDirectoryCompMetadata.DirectorySetMetadata.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
