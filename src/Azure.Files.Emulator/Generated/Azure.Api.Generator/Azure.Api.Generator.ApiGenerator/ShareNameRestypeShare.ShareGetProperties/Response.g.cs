using Corvus.Json;

namespace ShareNameRestypeShare.ShareGetProperties;
internal abstract partial class Response
{
    internal sealed class OK200 : Response
    {
        internal Corvus.Json.JsonAny ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal ShareNameRestypeShare.ShareGetProperties.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
