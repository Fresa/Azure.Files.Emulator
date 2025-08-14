using System.Threading;

namespace ShareNameDirectoryRestypeDirectoryCompRename.DirectoryRename;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}?restype=directory&comp=rename";
    internal const string Method = "DirectoryRename";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
