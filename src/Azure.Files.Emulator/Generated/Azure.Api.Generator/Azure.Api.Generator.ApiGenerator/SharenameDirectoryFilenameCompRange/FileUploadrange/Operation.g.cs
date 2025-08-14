using System.Threading;

namespace ShareNameDirectoryFileNameCompRange.FileUploadRange;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?comp=range";
    internal const string Method = "FileUploadRange";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
