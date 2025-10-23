using System.Threading;

namespace Azure.Files.Emulator.ShareNameRestypeShareCompStats.ShareGetStatistics;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}?restype=share&comp=stats";
    internal const string Method = "ShareGetStatistics";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
