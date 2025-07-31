using System.Threading;

namespace SharenameRestypeShareCompAcl.ShareSetaccesspolicy;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}?restype=share&comp=acl";
    internal const string Method = "ShareSetaccesspolicy";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
