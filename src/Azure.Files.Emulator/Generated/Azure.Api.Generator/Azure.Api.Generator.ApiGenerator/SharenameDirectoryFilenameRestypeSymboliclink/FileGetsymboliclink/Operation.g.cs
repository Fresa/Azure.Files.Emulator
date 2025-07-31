using System.Threading;

namespace SharenameDirectoryFilenameRestypeSymboliclink.FileGetsymboliclink;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?restype=symboliclink";
    internal const string Method = "FileGetsymboliclink";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
