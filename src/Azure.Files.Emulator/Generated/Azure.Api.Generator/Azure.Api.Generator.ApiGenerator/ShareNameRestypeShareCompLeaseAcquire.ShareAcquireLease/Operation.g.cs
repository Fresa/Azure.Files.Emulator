using System.Threading;

namespace ShareNameRestypeShareCompLeaseAcquire.ShareAcquireLease;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}?restype=share&comp=lease&acquire";
    internal const string Method = "ShareAcquireLease";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
