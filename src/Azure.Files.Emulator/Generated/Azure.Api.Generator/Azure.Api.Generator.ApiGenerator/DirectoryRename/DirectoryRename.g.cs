using System.Threading;

namespace SharenameDirectoryRestypeDirectoryCompRename.DirectoryRename;
internal partial class DirectoryRename
{
    internal const string PathTemplate = "/{shareName}/{directory}?restype=directory&comp=rename";
    internal const string Method = "Put";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
