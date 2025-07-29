using System.Threading;

namespace SharenameDirectoryFilename.FileDownload;
internal partial class FileDownload
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}";
    internal const string Method = "FileDownload";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
