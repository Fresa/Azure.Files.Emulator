using Corvus.Json;

namespace ShareNameRestypeShareCompSnapshot.ShareCreateSnapshot;
internal abstract partial class Response
{
    internal sealed class Created201 : Response
    {
        internal Corvus.Json.JsonAny ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal ShareNameRestypeShareCompSnapshot.ShareCreateSnapshot.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
