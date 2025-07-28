using System.Threading;

namespace SharenameDirectoryFilenameCompMetadata.FileSetmetadata;
internal partial class FileSetmetadata
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?comp=metadata";
    internal const string Method = "Put";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
