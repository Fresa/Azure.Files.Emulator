using System.Threading;

namespace SharenameDirectoryFilenameCompLeaseAcquire.FileAcquirelease;
internal partial class FileAcquirelease
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?comp=lease&acquire";
    internal const string Method = "Put";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
