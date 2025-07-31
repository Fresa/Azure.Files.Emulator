using System.Threading;

namespace SharenameRestypeShareCompProperties.ShareSetproperties;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}?restype=share&comp=properties";
    internal const string Method = "ShareSetproperties";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
