using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace ShareNameRestypeShareCompLeaseRenew.ShareRenewLease;
internal abstract partial class Response
{
    internal sealed class OK200 : Response
    {
    }

    internal sealed class Default : Response
    {
    }
}
