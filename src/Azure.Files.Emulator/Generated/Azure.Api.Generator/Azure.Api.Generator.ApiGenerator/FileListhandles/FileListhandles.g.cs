using System.Threading;

namespace SharenameDirectoryFilenameCompListhandles.FileListhandles;
internal partial class FileListhandles
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?comp=listhandles";
    internal const string Method = "Get";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
