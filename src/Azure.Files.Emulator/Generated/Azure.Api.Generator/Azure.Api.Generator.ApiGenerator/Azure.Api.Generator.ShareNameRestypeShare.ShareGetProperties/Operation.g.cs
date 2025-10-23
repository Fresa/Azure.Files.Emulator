using System.Threading;

namespace Azure.Files.Emulator.ShareNameRestypeShare.ShareGetProperties;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}?restype=share";
    internal const string Method = "ShareGetProperties";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
