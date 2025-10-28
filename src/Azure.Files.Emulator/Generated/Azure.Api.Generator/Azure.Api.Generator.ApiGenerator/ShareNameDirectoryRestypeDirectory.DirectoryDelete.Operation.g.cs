using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace Azure.Files.Emulator.ShareNameDirectoryRestypeDirectory.DirectoryDelete;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}?restype=directory";
    internal const string Method = "DELETE";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
    internal static async Task HandleAsync(HttpContext context, [FromServices] Operation operation, CancellationToken cancellationToken)
    {
        var request = await Request.BindAsync(context, cancellationToken).ConfigureAwait(false);
        var response = await operation.HandleAsync(request, cancellationToken).ConfigureAwait(false);
        response.WriteTo(context.Response);
    }
}
