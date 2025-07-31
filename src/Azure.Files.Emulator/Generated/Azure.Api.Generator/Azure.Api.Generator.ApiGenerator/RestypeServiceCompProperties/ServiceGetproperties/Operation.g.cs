using System.Threading;

namespace RestypeServiceCompProperties.ServiceGetproperties;
internal partial class Operation
{
    internal const string PathTemplate = "/?restype=service&comp=properties";
    internal const string Method = "ServiceGetproperties";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
