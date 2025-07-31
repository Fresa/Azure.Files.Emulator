using System.Threading;

namespace SharenameRestypeShare.ShareDelete;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}?restype=share";
    internal const string Method = "ShareDelete";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
