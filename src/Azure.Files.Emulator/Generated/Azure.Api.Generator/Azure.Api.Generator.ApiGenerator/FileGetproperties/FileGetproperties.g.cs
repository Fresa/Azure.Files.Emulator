using System.Threading;

namespace SharenameDirectoryFilename.FileGetproperties;
internal partial class FileGetproperties
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}";
    internal const string Method = "Head";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
