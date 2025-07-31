using System.Threading;

namespace SharenameDirectoryRestypeDirectory.DirectoryGetproperties;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}?restype=directory";
    internal const string Method = "DirectoryGetproperties";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
