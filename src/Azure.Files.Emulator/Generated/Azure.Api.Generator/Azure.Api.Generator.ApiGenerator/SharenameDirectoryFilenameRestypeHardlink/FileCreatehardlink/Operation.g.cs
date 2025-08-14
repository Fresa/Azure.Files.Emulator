using System.Threading;

namespace ShareNameDirectoryFileNameRestypeHardlink.FileCreateHardLink;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?restype=hardlink";
    internal const string Method = "FileCreateHardLink";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
