using System.Threading;

namespace SharenameDirectoryFilenameCompListhandles.FileListhandles;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?comp=listhandles";
    internal const string Method = "FileListhandles";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
