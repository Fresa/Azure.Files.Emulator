using System.Threading;

namespace Azure.Files.Emulator.ShareNameDirectoryFileNameCompListhandles.FileListHandles;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?comp=listhandles";
    internal const string Method = "FileListHandles";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
