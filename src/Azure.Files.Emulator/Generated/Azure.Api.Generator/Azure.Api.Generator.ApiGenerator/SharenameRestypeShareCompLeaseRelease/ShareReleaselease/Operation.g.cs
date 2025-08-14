using System.Threading;

namespace ShareNameRestypeShareCompLeaseRelease.ShareReleaseLease;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}?restype=share&comp=lease&release";
    internal const string Method = "ShareReleaseLease";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
