using System.Threading;

namespace ShareNameRestypeShareCompAcl.ShareSetAccessPolicy;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}?restype=share&comp=acl";
    internal const string Method = "ShareSetAccessPolicy";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
