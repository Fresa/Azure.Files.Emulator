using System.Threading;

namespace Azure.Files.Emulator.ShareNameDirectoryCompForceclosehandles.DirectoryForceCloseHandles;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}?comp=forceclosehandles";
    internal const string Method = "DirectoryForceCloseHandles";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
