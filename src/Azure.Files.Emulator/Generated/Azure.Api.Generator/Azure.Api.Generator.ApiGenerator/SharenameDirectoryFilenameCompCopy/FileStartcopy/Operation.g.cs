using System.Threading;

namespace SharenameDirectoryFilenameCompCopy.FileStartcopy;
internal partial class FileStartcopy
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?comp=copy";
    internal const string Method = "FileStartcopy";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
