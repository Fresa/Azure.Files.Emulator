using System.Threading;

namespace ShareNameDirectoryCompListhandles.DirectoryListHandles;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}?comp=listhandles";
    internal const string Method = "DirectoryListHandles";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
