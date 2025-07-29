using System.Threading;

namespace SharenameRestypeShareCompLeaseChange.ShareChangelease;
internal partial class ShareChangelease
{
    internal const string PathTemplate = "/{shareName}?restype=share&comp=lease&change";
    internal const string Method = "ShareChangelease";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
