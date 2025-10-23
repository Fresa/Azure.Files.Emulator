using System.Threading;

namespace Azure.Files.Emulator.ShareNameDirectoryFileName.FileDelete;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}";
    internal const string Method = "FileDelete";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
