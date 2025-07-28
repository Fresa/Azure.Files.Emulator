using System.Threading;

namespace SharenameRestypeShare.ShareCreate;
internal partial class ShareCreate
{
    internal const string PathTemplate = "/{shareName}?restype=share";
    internal const string Method = "Put";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
