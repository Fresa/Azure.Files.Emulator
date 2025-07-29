using System.Threading;

namespace SharenameRestypeShareCompUndelete.ShareRestore;
internal partial class ShareRestore
{
    internal const string PathTemplate = "/{shareName}?restype=share&comp=undelete";
    internal const string Method = "ShareRestore";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
