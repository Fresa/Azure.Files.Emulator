using System.Threading;

namespace RestypeServiceCompProperties.ServiceSetproperties;
internal partial class ServiceSetproperties
{
    internal const string PathTemplate = "/?restype=service&comp=properties";
    internal const string Method = "ServiceSetproperties";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
