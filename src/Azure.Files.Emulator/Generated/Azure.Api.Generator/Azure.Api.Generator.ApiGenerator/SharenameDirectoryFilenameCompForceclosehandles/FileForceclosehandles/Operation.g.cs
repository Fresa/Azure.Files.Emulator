using System.Threading;

namespace SharenameDirectoryFilenameCompForceclosehandles.FileForceclosehandles;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?comp=forceclosehandles";
    internal const string Method = "FileForceclosehandles";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
