using System.Threading;

namespace SharenameDirectoryFilenameCompCopyCopyid.FileAbortcopy;
internal partial class FileAbortcopy
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?comp=copy&copyid";
    internal const string Method = "FileAbortcopy";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
