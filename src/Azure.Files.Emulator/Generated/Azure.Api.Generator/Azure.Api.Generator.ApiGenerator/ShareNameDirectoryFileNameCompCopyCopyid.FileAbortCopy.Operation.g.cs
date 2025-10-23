using System.Threading;

namespace Azure.Files.Emulator.ShareNameDirectoryFileNameCompCopyCopyid.FileAbortCopy;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?comp=copy&copyid";
    internal const string Method = "FileAbortCopy";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
