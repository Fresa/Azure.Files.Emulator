using Corvus.Json;

namespace RestypeServiceCompProperties.ServiceGetProperties;
internal abstract partial class Response
{
    internal sealed class OK200 : Response
    {
        internal RestypeServiceCompProperties.ServiceGetProperties.Content._200.ApplicationXml ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal RestypeServiceCompProperties.ServiceGetProperties.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
