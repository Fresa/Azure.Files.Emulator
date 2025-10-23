using System.Threading;

namespace Azure.Files.Emulator.ShareNameDirectoryRestypeDirectory.DirectoryDelete;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}?restype=directory";
    internal const string Method = "DirectoryDelete";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
