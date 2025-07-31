using System.Threading;

namespace SharenameRestypeShareCompMetadata.ShareSetmetadata;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}?restype=share&comp=metadata";
    internal const string Method = "ShareSetmetadata";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
