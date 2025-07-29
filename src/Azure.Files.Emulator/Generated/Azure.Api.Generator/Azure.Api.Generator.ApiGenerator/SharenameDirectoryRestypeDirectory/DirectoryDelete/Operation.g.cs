using System.Threading;

namespace SharenameDirectoryRestypeDirectory.DirectoryDelete;
internal partial class DirectoryDelete
{
    internal const string PathTemplate = "/{shareName}/{directory}?restype=directory";
    internal const string Method = "DirectoryDelete";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
