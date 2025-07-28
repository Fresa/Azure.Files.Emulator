using System.Threading;

namespace SharenameRestypeShareCompAcl.ShareSetaccesspolicy;
internal partial class ShareSetaccesspolicy
{
    internal const string PathTemplate = "/{shareName}?restype=share&comp=acl";
    internal const string Method = "Put";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
