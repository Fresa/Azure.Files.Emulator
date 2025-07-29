using System.Threading;

namespace SharenameDirectoryFilenameCompRangeFromurl.FileUploadrangefromurl;
internal partial class FileUploadrangefromurl
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?comp=range&fromURL";
    internal const string Method = "FileUploadrangefromurl";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
