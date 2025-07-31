using System.Threading;

namespace SharenameDirectoryFilenameCompLeaseAcquire.FileAcquirelease;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?comp=lease&acquire";
    internal const string Method = "FileAcquirelease";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
