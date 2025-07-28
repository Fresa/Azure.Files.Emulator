using System.Threading;

namespace RestypeServiceCompProperties.ServiceGetproperties;
internal partial class ServiceGetproperties
{
    internal const string PathTemplate = "/?restype=service&comp=properties";
    internal const string Method = "Get";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
