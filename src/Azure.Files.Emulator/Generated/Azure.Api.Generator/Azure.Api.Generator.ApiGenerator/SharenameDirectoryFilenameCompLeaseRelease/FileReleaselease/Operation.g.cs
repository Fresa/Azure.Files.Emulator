using System.Threading;

namespace SharenameDirectoryFilenameCompLeaseRelease.FileReleaselease;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?comp=lease&release";
    internal const string Method = "FileReleaselease";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
