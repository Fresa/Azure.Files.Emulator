using System.Threading;

namespace ShareNameRestypeShareCompLeaseBreak.ShareBreakLease;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}?restype=share&comp=lease&break";
    internal const string Method = "ShareBreakLease";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
