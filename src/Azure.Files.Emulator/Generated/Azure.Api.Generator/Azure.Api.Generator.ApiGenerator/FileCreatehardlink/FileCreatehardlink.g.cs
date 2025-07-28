using System.Threading;

namespace SharenameDirectoryFilenameRestypeHardlink.FileCreatehardlink;
internal partial class FileCreatehardlink
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?restype=hardlink";
    internal const string Method = "Put";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
