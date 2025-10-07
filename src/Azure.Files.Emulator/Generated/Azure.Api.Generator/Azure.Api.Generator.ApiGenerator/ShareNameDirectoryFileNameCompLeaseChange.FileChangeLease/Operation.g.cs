using System.Threading;

namespace ShareNameDirectoryFileNameCompLeaseChange.FileChangeLease;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?comp=lease&change";
    internal const string Method = "FileChangeLease";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
