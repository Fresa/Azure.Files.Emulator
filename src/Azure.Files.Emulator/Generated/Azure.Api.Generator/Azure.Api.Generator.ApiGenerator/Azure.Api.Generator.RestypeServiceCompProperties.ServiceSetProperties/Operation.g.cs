using System.Threading;

namespace Azure.Files.Emulator.RestypeServiceCompProperties.ServiceSetProperties;
internal partial class Operation
{
    internal const string PathTemplate = "/?restype=service&comp=properties";
    internal const string Method = "ServiceSetProperties";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
