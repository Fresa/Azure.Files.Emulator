using System.Threading;

namespace ShareNameRestypeShareCompAcl.ShareGetAccessPolicy;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}?restype=share&comp=acl";
    internal const string Method = "ShareGetAccessPolicy";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
