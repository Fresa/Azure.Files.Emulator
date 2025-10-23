using System.Threading;

namespace Azure.Files.Emulator.ShareNameRestypeShare.ShareDelete;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}?restype=share";
    internal const string Method = "ShareDelete";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
