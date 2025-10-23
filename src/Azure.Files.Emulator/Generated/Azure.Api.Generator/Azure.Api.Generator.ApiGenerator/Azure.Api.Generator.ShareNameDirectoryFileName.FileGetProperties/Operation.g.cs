using System.Threading;

namespace Azure.Files.Emulator.ShareNameDirectoryFileName.FileGetProperties;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}";
    internal const string Method = "FileGetProperties";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
