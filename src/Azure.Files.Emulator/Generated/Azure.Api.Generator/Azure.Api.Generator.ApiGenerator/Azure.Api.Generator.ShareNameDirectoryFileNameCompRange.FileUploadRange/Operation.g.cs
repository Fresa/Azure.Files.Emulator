using System.Threading;

namespace Azure.Files.Emulator.ShareNameDirectoryFileNameCompRange.FileUploadRange;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?comp=range";
    internal const string Method = "FileUploadRange";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
