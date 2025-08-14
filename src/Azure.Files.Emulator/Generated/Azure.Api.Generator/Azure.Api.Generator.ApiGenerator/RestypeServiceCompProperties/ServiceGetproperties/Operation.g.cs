using System.Threading;

namespace RestypeServiceCompProperties.ServiceGetProperties;
internal partial class Operation
{
    internal const string PathTemplate = "/?restype=service&comp=properties";
    internal const string Method = "ServiceGetProperties";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
