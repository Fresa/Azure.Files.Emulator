using System.Threading;

namespace Azure.Files.Emulator.ShareNameDirectoryFileNameRestypeSymboliclink.FileGetSymbolicLink;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?restype=symboliclink";
    internal const string Method = "FileGetSymbolicLink";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
