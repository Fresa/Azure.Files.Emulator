using Corvus.Json;

namespace Azure.Files.Emulator.ShareNameRestypeShare.ShareCreate;
internal abstract partial class Response
{
    internal sealed class Created201 : Response
    {
        internal Corvus.Json.JsonAny ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal Azure.Files.Emulator.ShareNameRestypeShare.ShareCreate.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
