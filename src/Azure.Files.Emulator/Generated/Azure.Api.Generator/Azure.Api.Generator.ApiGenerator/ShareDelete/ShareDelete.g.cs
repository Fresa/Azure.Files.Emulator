using System.Threading;

namespace SharenameRestypeShare.ShareDelete;
internal partial class ShareDelete
{
    internal const string PathTemplate = "/{shareName}?restype=share";
    internal const string Method = "Delete";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
