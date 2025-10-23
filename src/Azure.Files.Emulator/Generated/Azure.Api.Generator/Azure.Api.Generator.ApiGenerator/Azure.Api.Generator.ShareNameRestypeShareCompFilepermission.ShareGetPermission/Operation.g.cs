using System.Threading;

namespace Azure.Files.Emulator.ShareNameRestypeShareCompFilepermission.ShareGetPermission;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}?restype=share&comp=filepermission";
    internal const string Method = "ShareGetPermission";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
