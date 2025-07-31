using System.Threading;

namespace SharenameDirectoryFilenameRestypeHardlink.FileCreatehardlink;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?restype=hardlink";
    internal const string Method = "FileCreatehardlink";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
