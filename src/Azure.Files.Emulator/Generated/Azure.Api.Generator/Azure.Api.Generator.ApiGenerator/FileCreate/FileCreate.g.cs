using System.Threading;

namespace SharenameDirectoryFilename.FileCreate;
internal partial class FileCreate
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}";
    internal const string Method = "Put";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
