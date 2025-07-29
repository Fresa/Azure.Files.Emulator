using System.Threading;

namespace SharenameRestypeShareCompStats.ShareGetstatistics;
internal partial class ShareGetstatistics
{
    internal const string PathTemplate = "/{shareName}?restype=share&comp=stats";
    internal const string Method = "ShareGetstatistics";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
