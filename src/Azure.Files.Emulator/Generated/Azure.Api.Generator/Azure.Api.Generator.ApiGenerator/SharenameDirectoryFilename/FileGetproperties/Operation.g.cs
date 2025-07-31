using System.Threading;

namespace SharenameDirectoryFilename.FileGetproperties;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}";
    internal const string Method = "FileGetproperties";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
