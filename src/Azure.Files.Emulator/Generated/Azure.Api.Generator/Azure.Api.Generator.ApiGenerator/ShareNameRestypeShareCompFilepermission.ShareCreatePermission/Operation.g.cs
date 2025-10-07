using System.Threading;

namespace ShareNameRestypeShareCompFilepermission.ShareCreatePermission;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}?restype=share&comp=filepermission";
    internal const string Method = "ShareCreatePermission";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
