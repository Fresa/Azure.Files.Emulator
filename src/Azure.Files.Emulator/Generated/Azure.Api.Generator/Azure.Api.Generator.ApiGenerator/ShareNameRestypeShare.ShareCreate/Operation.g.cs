using System.Threading;

namespace ShareNameRestypeShare.ShareCreate;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}?restype=share";
    internal const string Method = "ShareCreate";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
