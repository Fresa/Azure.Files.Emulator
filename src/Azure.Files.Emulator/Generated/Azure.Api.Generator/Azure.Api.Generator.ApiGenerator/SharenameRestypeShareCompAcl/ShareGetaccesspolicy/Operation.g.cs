using System.Threading;

namespace SharenameRestypeShareCompAcl.ShareGetaccesspolicy;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}?restype=share&comp=acl";
    internal const string Method = "ShareGetaccesspolicy";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
