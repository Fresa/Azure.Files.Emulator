using System.Threading;

namespace SharenameDirectoryFilenameCompRange.FileUploadrange;
internal partial class FileUploadrange
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?comp=range";
    internal const string Method = "Put";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
