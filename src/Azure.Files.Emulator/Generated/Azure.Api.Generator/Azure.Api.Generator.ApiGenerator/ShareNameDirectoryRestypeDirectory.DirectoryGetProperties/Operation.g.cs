using System.Threading;

namespace ShareNameDirectoryRestypeDirectory.DirectoryGetProperties;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}?restype=directory";
    internal const string Method = "DirectoryGetProperties";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
