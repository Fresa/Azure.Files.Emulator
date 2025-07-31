using System.Threading;

namespace SharenameRestypeShareCompLeaseAcquire.ShareAcquirelease;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}?restype=share&comp=lease&acquire";
    internal const string Method = "ShareAcquirelease";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
