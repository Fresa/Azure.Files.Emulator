using System.Threading;

namespace ShareNameDirectoryFileName.FileDownload;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}";
    internal const string Method = "FileDownload";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
