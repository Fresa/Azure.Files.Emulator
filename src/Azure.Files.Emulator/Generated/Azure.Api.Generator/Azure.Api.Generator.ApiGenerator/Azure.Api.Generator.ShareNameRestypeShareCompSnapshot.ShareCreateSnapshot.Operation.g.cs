using System.Threading;

namespace Azure.Files.Emulator.ShareNameRestypeShareCompSnapshot.ShareCreateSnapshot;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}?restype=share&comp=snapshot";
    internal const string Method = "ShareCreateSnapshot";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
