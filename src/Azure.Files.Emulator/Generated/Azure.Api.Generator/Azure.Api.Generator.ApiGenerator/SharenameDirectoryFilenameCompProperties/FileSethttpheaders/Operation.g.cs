using System.Threading;

namespace SharenameDirectoryFilenameCompProperties.FileSethttpheaders;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?comp=properties";
    internal const string Method = "FileSethttpheaders";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
