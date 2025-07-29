using System.Threading;

namespace SharenameDirectoryFilenameRestypeSymboliclink.FileCreatesymboliclink;
internal partial class FileCreatesymboliclink
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?restype=symboliclink";
    internal const string Method = "FileCreatesymboliclink";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
