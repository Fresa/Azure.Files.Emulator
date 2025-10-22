using Corvus.Json;

namespace ShareNameDirectoryFileNameCompListhandles.FileListHandles;
internal abstract partial class Response
{
    internal sealed class OK200 : Response
    {
        internal ShareNameDirectoryFileNameCompListhandles.FileListHandles.Content._200.ApplicationXml ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal ShareNameDirectoryFileNameCompListhandles.FileListHandles.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
