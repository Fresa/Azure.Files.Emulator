using Corvus.Json;

namespace ShareNameRestypeShare.ShareDelete;
internal abstract partial class Response
{
    internal sealed class Accepted202 : Response
    {
        internal Corvus.Json.JsonAny ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal ShareNameRestypeShare.ShareDelete.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
