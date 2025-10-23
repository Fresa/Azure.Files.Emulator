using System.Threading;

namespace Azure.Files.Emulator.ShareNameDirectoryFileNameCompLeaseAcquire.FileAcquireLease;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?comp=lease&acquire";
    internal const string Method = "FileAcquireLease";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
