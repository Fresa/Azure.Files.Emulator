using System.Threading;

namespace SharenameRestypeShareCompSnapshot.ShareCreatesnapshot;
internal partial class ShareCreatesnapshot
{
    internal const string PathTemplate = "/{shareName}?restype=share&comp=snapshot";
    internal const string Method = "Put";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
