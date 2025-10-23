using System.Threading;

namespace Azure.Files.Emulator.ShareNameRestypeShareCompLeaseRenew.ShareRenewLease;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}?restype=share&comp=lease&renew";
    internal const string Method = "ShareRenewLease";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
