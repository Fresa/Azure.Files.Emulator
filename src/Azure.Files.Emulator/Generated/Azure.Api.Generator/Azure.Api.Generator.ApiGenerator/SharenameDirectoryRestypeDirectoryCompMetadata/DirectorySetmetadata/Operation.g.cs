using System.Threading;

namespace SharenameDirectoryRestypeDirectoryCompMetadata.DirectorySetmetadata;
internal partial class DirectorySetmetadata
{
    internal const string PathTemplate = "/{shareName}/{directory}?restype=directory&comp=metadata";
    internal const string Method = "DirectorySetmetadata";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
