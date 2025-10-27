using System.Threading;

namespace Azure.Files.Emulator.ShareNameRestypeShareCompUndelete.ShareRestore;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}?restype=share&comp=undelete";
    internal const string Method = "PUT";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
    internal static async Task HandleAsync(HttpContext context, Operation operation, CancellationToken cancellationToken)
    {
        var request = await Request.BindAsync(context, cancellationToken).ConfigureAwait(false);
        var response = await operation.HandleAsync(request, cancellationToken).ConfigureAwait(false);
        response.WriteTo(context.Response);
    }
}
