using Corvus.Json;

namespace Azure.Files.Emulator.ShareNameDirectoryCompListhandles.DirectoryListHandles;
internal abstract partial class Response
{
    internal sealed class OK200 : Response
    {
        internal Azure.Files.Emulator.ShareNameDirectoryCompListhandles.DirectoryListHandles.Content._200.ApplicationXml ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal Azure.Files.Emulator.ShareNameDirectoryCompListhandles.DirectoryListHandles.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
