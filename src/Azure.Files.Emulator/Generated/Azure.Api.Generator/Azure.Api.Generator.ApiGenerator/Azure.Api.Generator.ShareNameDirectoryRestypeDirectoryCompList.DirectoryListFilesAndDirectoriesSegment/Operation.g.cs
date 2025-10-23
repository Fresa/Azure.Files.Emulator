using System.Threading;

namespace Azure.Files.Emulator.ShareNameDirectoryRestypeDirectoryCompList.DirectoryListFilesAndDirectoriesSegment;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}?restype=directory&comp=list";
    internal const string Method = "DirectoryListFilesAndDirectoriesSegment";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
