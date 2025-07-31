using System.Threading;

namespace SharenameDirectoryFilename.FileCreate;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}";
    internal const string Method = "FileCreate";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
