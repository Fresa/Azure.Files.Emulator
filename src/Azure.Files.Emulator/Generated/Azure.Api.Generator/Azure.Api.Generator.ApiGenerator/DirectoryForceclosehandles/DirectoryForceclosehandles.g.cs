using System.Threading;

namespace SharenameDirectoryCompForceclosehandles.DirectoryForceclosehandles;
internal partial class DirectoryForceclosehandles
{
    internal const string PathTemplate = "/{shareName}/{directory}?comp=forceclosehandles";
    internal const string Method = "Put";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
