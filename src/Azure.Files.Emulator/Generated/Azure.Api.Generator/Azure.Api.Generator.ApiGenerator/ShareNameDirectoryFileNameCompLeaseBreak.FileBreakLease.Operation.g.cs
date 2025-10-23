using System.Threading;

namespace Azure.Files.Emulator.ShareNameDirectoryFileNameCompLeaseBreak.FileBreakLease;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?comp=lease&break";
    internal const string Method = "FileBreakLease";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
