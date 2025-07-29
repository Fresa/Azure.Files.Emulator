using System.Threading;

namespace SharenameDirectoryRestypeDirectory.DirectoryCreate;
internal partial class DirectoryCreate
{
    internal const string PathTemplate = "/{shareName}/{directory}?restype=directory";
    internal const string Method = "DirectoryCreate";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
