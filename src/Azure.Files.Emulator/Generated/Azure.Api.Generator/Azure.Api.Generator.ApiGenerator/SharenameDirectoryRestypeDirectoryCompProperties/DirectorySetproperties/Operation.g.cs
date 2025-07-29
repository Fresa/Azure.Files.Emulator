using System.Threading;

namespace SharenameDirectoryRestypeDirectoryCompProperties.DirectorySetproperties;
internal partial class DirectorySetproperties
{
    internal const string PathTemplate = "/{shareName}/{directory}?restype=directory&comp=properties";
    internal const string Method = "DirectorySetproperties";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
