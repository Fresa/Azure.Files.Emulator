using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace ShareNameDirectoryRestypeDirectoryCompList.DirectoryListFilesAndDirectoriesSegment;
internal abstract partial class Response
{
    internal sealed class OK200 : Response
    {
        internal ShareNameDirectoryRestypeDirectoryCompList.DirectoryListFilesAndDirectoriesSegment.Content._200.ApplicationXml ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal ShareNameDirectoryRestypeDirectoryCompList.DirectoryListFilesAndDirectoriesSegment.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
