using System.Threading;

namespace Azure.Files.Emulator.ShareNameRestypeShareCompFilepermission.ShareCreatePermission;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}?restype=share&comp=filepermission";
    internal const string Method = "PUT";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
    internal static async Task HandleAsync(HttpContext context, Operation operation, CancellationToken cancellationToken)
    {
        var request = Request.Bind(context);
        var response = await operation.HandleAsync(request, cancellationToken).ConfigureAwait(false);
        response.WriteTo(context.Response);
    }
}
