using System.Threading;

namespace Azure.Files.Emulator.CompList.ServiceListSharesSegment;
internal partial class Operation
{
    internal const string PathTemplate = "/?comp=list";
    internal const string Method = "ServiceListSharesSegment";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
    internal static async Task HandleAsync(HttpContext context, Operation operation, CancellationToken cancellationToken)
    {
        var request = Request.Bind(context);
        var response = await operation.HandleAsync(request, cancellationToken).ConfigureAwait(false);
        response.WriteTo(context.Response);
    }
}
