using System.Threading;

namespace SharenameDirectoryFilename.FileDelete;
internal partial class FileDelete
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}";
    internal const string Method = "Delete";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
