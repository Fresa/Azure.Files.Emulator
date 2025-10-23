using System.Threading;

namespace Azure.Files.Emulator.ShareNameDirectoryFileNameCompProperties.FileSetHTTPHeaders;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?comp=properties";
    internal const string Method = "FileSetHTTPHeaders";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
