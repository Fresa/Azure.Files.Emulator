using System.Threading;

namespace SharenameDirectoryCompListhandles.DirectoryListhandles;
internal partial class DirectoryListhandles
{
    internal const string PathTemplate = "/{shareName}/{directory}?comp=listhandles";
    internal const string Method = "Get";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
