using System.Threading;

namespace SharenameRestypeShareCompLeaseRenew.ShareRenewlease;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}?restype=share&comp=lease&renew";
    internal const string Method = "ShareRenewlease";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
