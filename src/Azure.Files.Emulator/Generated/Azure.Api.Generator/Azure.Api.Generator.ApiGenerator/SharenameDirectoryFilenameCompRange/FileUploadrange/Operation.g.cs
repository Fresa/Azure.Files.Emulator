using System.Threading;

namespace SharenameDirectoryFilenameCompRange.FileUploadrange;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?comp=range";
    internal const string Method = "FileUploadrange";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
