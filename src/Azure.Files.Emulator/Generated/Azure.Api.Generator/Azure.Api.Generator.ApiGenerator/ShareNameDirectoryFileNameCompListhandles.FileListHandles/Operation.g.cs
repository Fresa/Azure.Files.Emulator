using System.Threading;

namespace ShareNameDirectoryFileNameCompListhandles.FileListHandles;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?comp=listhandles";
    internal const string Method = "FileListHandles";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
