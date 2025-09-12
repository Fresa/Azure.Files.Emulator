using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace RestypeServiceCompProperties.ServiceSetProperties;
internal abstract partial class Response
{
    internal sealed class Accepted202 : Response
    {
        internal Corvus.Json.JsonAny ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal RestypeServiceCompProperties.ServiceSetProperties.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
