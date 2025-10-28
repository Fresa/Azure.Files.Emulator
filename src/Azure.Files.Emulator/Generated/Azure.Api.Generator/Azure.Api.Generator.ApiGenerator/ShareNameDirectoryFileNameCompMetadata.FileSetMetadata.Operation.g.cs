using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace Azure.Files.Emulator.ShareNameDirectoryFileNameCompMetadata.FileSetMetadata;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?comp=metadata";
    internal const string Method = "PUT";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
    internal static async Task HandleAsync(HttpContext context, [FromServices] Operation operation, CancellationToken cancellationToken)
    {
        var request = await Request.BindAsync(context, cancellationToken).ConfigureAwait(false);
        var response = await operation.HandleAsync(request, cancellationToken).ConfigureAwait(false);
        response.WriteTo(context.Response);
    }
}
