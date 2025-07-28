using System.Threading;

namespace SharenameRestypeShare.ShareGetproperties;
internal partial class ShareGetproperties
{
    internal const string PathTemplate = "/{shareName}?restype=share";
    internal const string Method = "Get";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
