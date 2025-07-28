using System.Threading;

namespace SharenameDirectoryFilenameCompLeaseChange.FileChangelease;
internal partial class FileChangelease
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?comp=lease&change";
    internal const string Method = "Put";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
