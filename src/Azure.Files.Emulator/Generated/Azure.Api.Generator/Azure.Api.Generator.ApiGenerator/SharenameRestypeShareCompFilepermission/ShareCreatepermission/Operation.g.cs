using System.Threading;

namespace SharenameRestypeShareCompFilepermission.ShareCreatepermission;
internal partial class ShareCreatepermission
{
    internal const string PathTemplate = "/{shareName}?restype=share&comp=filepermission";
    internal const string Method = "ShareCreatepermission";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
