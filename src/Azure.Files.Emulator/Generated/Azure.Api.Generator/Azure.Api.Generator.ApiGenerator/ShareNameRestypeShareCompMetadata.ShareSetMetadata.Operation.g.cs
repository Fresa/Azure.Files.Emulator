using System.Threading;

namespace Azure.Files.Emulator.ShareNameRestypeShareCompMetadata.ShareSetMetadata;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}?restype=share&comp=metadata";
    internal const string Method = "ShareSetMetadata";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
