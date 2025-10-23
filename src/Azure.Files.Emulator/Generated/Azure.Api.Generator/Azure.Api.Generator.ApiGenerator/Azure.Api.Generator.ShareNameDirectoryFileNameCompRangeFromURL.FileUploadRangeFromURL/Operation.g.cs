using System.Threading;

namespace Azure.Files.Emulator.ShareNameDirectoryFileNameCompRangeFromURL.FileUploadRangeFromURL;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?comp=range&fromURL";
    internal const string Method = "FileUploadRangeFromURL";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
