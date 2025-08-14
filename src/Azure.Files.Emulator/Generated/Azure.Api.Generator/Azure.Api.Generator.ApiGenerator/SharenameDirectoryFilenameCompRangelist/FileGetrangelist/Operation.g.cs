using System.Threading;

namespace ShareNameDirectoryFileNameCompRangelist.FileGetRangeList;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?comp=rangelist";
    internal const string Method = "FileGetRangeList";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
