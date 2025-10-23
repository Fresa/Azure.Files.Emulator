using Corvus.Json;

namespace Azure.Files.Emulator.ShareNameDirectoryRestypeDirectoryCompList.DirectoryListFilesAndDirectoriesSegment;
internal abstract partial class Response
{
    internal sealed class OK200 : Response
    {
        internal Azure.Files.Emulator.ShareNameDirectoryRestypeDirectoryCompList.DirectoryListFilesAndDirectoriesSegment.Content._200.ApplicationXml ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal Azure.Files.Emulator.ShareNameDirectoryRestypeDirectoryCompList.DirectoryListFilesAndDirectoriesSegment.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
