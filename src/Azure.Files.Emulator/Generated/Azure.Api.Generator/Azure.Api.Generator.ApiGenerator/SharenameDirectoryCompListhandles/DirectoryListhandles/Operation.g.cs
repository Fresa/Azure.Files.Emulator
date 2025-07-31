using System.Threading;

namespace SharenameDirectoryCompListhandles.DirectoryListhandles;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}?comp=listhandles";
    internal const string Method = "DirectoryListhandles";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
