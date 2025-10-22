using Corvus.Json;

namespace ShareNameRestypeShareCompLeaseAcquire.ShareAcquireLease;
internal abstract partial class Response
{
    internal sealed class Created201 : Response
    {
        internal Corvus.Json.JsonAny ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal ShareNameRestypeShareCompLeaseAcquire.ShareAcquireLease.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
