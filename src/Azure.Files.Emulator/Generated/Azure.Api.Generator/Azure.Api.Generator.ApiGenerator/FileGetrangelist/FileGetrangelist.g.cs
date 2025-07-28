using System.Threading;

namespace SharenameDirectoryFilenameCompRangelist.FileGetrangelist;
internal partial class FileGetrangelist
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?comp=rangelist";
    internal const string Method = "Get";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
