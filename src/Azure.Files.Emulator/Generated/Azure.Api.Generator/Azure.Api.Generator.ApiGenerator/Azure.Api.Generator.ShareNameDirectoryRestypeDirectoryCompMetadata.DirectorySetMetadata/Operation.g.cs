using System.Threading;

namespace Azure.Files.Emulator.ShareNameDirectoryRestypeDirectoryCompMetadata.DirectorySetMetadata;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}?restype=directory&comp=metadata";
    internal const string Method = "DirectorySetMetadata";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
