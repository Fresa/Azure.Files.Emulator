using System.Threading;

namespace ShareNameDirectoryFileNameRestypeSymboliclink.FileCreateSymbolicLink;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?restype=symboliclink";
    internal const string Method = "FileCreateSymbolicLink";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
