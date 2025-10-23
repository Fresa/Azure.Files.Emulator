using System.Threading;

namespace Azure.Files.Emulator.ShareNameDirectoryRestypeDirectoryCompProperties.DirectorySetProperties;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}?restype=directory&comp=properties";
    internal const string Method = "DirectorySetProperties";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
