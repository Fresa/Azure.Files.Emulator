using System.Threading;

namespace SharenameRestypeShareCompProperties.ShareSetproperties;
internal partial class ShareSetproperties
{
    internal const string PathTemplate = "/{shareName}?restype=share&comp=properties";
    internal const string Method = "Put";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
