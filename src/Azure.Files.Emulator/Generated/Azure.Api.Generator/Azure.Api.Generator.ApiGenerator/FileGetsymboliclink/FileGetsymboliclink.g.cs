using System.Threading;

namespace SharenameDirectoryFilenameRestypeSymboliclink.FileGetsymboliclink;
internal partial class FileGetsymboliclink
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?restype=symboliclink";
    internal const string Method = "Get";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
