using System.Threading;

namespace SharenameDirectoryRestypeDirectory.DirectoryGetproperties;
internal partial class DirectoryGetproperties
{
    internal const string PathTemplate = "/{shareName}/{directory}?restype=directory";
    internal const string Method = "Get";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
