using System.Threading;

namespace SharenameDirectoryFilenameCompRename.FileRename;
internal partial class FileRename
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?comp=rename";
    internal const string Method = "FileRename";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
