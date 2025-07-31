using System.Threading;

namespace SharenameDirectoryFilenameCompLeaseChange.FileChangelease;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?comp=lease&change";
    internal const string Method = "FileChangelease";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
