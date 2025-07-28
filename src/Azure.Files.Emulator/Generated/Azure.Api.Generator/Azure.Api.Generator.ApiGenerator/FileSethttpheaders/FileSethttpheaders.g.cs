using System.Threading;

namespace SharenameDirectoryFilenameCompProperties.FileSethttpheaders;
internal partial class FileSethttpheaders
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?comp=properties";
    internal const string Method = "Put";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
