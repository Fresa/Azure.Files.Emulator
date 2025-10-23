using System.Threading;

namespace Azure.Files.Emulator.ShareNameRestypeShareCompLeaseChange.ShareChangeLease;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}?restype=share&comp=lease&change";
    internal const string Method = "ShareChangeLease";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
