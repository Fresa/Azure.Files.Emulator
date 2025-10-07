using System.Threading;

namespace ShareNameDirectoryFileNameCompRename.FileRename;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?comp=rename";
    internal const string Method = "FileRename";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
