using System.Threading;

namespace CompList.ServiceListsharessegment;
internal partial class ServiceListsharessegment
{
    internal const string PathTemplate = "/?comp=list";
    internal const string Method = "ServiceListsharessegment";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
