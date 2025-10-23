using Corvus.Json;

namespace Azure.Files.Emulator.ShareNameDirectoryRestypeDirectoryCompRename.DirectoryRename;
internal abstract partial class Response
{
    internal sealed class OK200 : Response
    {
        internal Corvus.Json.JsonAny ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal Azure.Files.Emulator.ShareNameDirectoryRestypeDirectoryCompRename.DirectoryRename.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
