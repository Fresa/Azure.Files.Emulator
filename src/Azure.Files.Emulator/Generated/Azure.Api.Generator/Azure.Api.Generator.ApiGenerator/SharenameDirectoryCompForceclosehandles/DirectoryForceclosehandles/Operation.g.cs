using System.Threading;

namespace SharenameDirectoryCompForceclosehandles.DirectoryForceclosehandles;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}?comp=forceclosehandles";
    internal const string Method = "DirectoryForceclosehandles";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
