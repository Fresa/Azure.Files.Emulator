using System.Threading;

namespace SharenameDirectoryFilenameCompForceclosehandles.FileForceclosehandles;
internal partial class FileForceclosehandles
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?comp=forceclosehandles";
    internal const string Method = "Put";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
