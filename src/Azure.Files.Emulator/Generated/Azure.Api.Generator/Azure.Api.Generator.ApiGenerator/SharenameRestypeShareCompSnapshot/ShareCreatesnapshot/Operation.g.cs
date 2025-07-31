using System.Threading;

namespace SharenameRestypeShareCompSnapshot.ShareCreatesnapshot;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}?restype=share&comp=snapshot";
    internal const string Method = "ShareCreatesnapshot";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
