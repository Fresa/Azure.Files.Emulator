using System.Threading;

namespace Azure.Files.Emulator.ShareNameDirectoryFileNameCompLeaseRelease.FileReleaseLease;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?comp=lease&release";
    internal const string Method = "FileReleaseLease";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
