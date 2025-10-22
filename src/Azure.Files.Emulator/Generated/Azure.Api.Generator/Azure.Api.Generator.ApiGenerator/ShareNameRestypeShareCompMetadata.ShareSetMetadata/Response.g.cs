using Corvus.Json;

namespace ShareNameRestypeShareCompMetadata.ShareSetMetadata;
internal abstract partial class Response
{
    internal sealed class OK200 : Response
    {
        internal Corvus.Json.JsonAny ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal ShareNameRestypeShareCompMetadata.ShareSetMetadata.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
