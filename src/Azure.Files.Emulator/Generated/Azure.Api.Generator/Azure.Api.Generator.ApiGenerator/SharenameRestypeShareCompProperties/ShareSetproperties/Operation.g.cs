using System.Threading;

namespace ShareNameRestypeShareCompProperties.ShareSetProperties;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}?restype=share&comp=properties";
    internal const string Method = "ShareSetProperties";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
