using System.Threading;

namespace Azure.Files.Emulator.ShareNameDirectoryRestypeDirectory.DirectoryDelete;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}?restype=directory";
    internal const string Method = "DirectoryDelete";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
    internal static async Task HandleAsync(HttpContext context, Operation operation, CancellationToken cancellationToken)
    {
        var request = Request.Bind(context.Request);
        var response = await operation.HandleAsync(request, cancellationToken).ConfigureAwait(false);
        response.WriteTo(context.Response);
    }
}
