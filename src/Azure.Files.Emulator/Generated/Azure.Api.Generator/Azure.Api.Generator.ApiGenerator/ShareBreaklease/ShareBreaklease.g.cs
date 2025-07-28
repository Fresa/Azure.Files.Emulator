using System.Threading;

namespace SharenameRestypeShareCompLeaseBreak.ShareBreaklease;
internal partial class ShareBreaklease
{
    internal const string PathTemplate = "/{shareName}?restype=share&comp=lease&break";
    internal const string Method = "Put";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
