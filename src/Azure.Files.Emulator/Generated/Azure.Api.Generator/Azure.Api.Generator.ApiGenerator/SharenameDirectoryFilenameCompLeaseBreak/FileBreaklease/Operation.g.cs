using System.Threading;

namespace SharenameDirectoryFilenameCompLeaseBreak.FileBreaklease;
internal partial class FileBreaklease
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?comp=lease&break";
    internal const string Method = "FileBreaklease";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
