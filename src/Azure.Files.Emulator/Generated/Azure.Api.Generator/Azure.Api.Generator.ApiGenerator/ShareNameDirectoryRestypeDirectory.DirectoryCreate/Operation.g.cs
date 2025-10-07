using System.Threading;

namespace ShareNameDirectoryRestypeDirectory.DirectoryCreate;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}?restype=directory";
    internal const string Method = "DirectoryCreate";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
