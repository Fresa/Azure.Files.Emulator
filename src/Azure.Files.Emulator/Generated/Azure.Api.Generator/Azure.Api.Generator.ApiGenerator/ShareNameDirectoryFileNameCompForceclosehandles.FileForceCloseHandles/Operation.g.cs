using System.Threading;

namespace ShareNameDirectoryFileNameCompForceclosehandles.FileForceCloseHandles;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?comp=forceclosehandles";
    internal const string Method = "FileForceCloseHandles";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
