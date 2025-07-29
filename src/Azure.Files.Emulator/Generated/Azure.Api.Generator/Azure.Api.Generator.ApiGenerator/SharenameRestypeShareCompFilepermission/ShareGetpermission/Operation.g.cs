using System.Threading;

namespace SharenameRestypeShareCompFilepermission.ShareGetpermission;
internal partial class ShareGetpermission
{
    internal const string PathTemplate = "/{shareName}?restype=share&comp=filepermission";
    internal const string Method = "ShareGetpermission";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
