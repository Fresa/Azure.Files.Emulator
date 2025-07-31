using System.Threading;

namespace SharenameDirectoryFilenameCompRangelist.FileGetrangelist;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?comp=rangelist";
    internal const string Method = "FileGetrangelist";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
