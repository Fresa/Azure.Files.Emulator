using Corvus.Json;

namespace Azure.Files.Emulator.ShareNameDirectoryFileNameCompListhandles.FileListHandles;
internal abstract partial class Response
{
    internal sealed class OK200 : Response
    {
        internal Azure.Files.Emulator.ShareNameDirectoryFileNameCompListhandles.FileListHandles.Content._200.ApplicationXml ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal Azure.Files.Emulator.ShareNameDirectoryFileNameCompListhandles.FileListHandles.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
