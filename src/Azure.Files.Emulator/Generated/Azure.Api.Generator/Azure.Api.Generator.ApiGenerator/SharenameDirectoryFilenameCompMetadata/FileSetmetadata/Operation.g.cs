using System.Threading;

namespace SharenameDirectoryFilenameCompMetadata.FileSetmetadata;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?comp=metadata";
    internal const string Method = "FileSetmetadata";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
