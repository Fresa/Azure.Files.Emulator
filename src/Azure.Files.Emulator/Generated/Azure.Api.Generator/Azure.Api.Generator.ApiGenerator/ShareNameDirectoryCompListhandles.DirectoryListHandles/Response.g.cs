using Corvus.Json;

namespace ShareNameDirectoryCompListhandles.DirectoryListHandles;
internal abstract partial class Response
{
    internal sealed class OK200 : Response
    {
        internal ShareNameDirectoryCompListhandles.DirectoryListHandles.Content._200.ApplicationXml ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal ShareNameDirectoryCompListhandles.DirectoryListHandles.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
