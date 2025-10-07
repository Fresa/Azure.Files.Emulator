using System.Threading;

namespace CompList.ServiceListSharesSegment;
internal partial class Operation
{
    internal const string PathTemplate = "/?comp=list";
    internal const string Method = "ServiceListSharesSegment";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
