using System.Threading;

namespace Azure.Files.Emulator.ShareNameRestypeShareCompStats.ShareGetStatistics;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}?restype=share&comp=stats";
    internal const string Method = "ShareGetStatistics";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
    internal static async Task HandleAsync(HttpContext context, Operation operation, CancellationToken cancellationToken)
    {
        var request = Request.Bind(context);
        var response = await operation.HandleAsync(request, cancellationToken).ConfigureAwait(false);
        response.WriteTo(context.Response);
    }
}
