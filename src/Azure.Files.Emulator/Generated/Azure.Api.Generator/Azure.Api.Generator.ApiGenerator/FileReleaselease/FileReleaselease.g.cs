using System.Threading;

namespace SharenameDirectoryFilenameCompLeaseRelease.FileReleaselease;
internal partial class FileReleaselease
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?comp=lease&release";
    internal const string Method = "Put";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
