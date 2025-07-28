using System.Threading;

namespace SharenameRestypeShareCompFilepermission.ShareGetpermission;
internal partial class ShareGetpermission
{
    internal const string PathTemplate = "/{shareName}?restype=share&comp=filepermission";
    internal const string Method = "Get";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
