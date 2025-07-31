using System.Threading;

namespace SharenameRestypeShareCompLeaseRelease.ShareReleaselease;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}?restype=share&comp=lease&release";
    internal const string Method = "ShareReleaselease";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
