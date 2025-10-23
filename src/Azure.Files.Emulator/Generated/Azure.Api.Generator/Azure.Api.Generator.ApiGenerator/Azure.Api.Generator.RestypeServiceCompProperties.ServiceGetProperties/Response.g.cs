using Corvus.Json;

namespace Azure.Files.Emulator.RestypeServiceCompProperties.ServiceGetProperties;
internal abstract partial class Response
{
    internal sealed class OK200 : Response
    {
        internal Azure.Files.Emulator.RestypeServiceCompProperties.ServiceGetProperties.Content._200.ApplicationXml ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal Azure.Files.Emulator.RestypeServiceCompProperties.ServiceGetProperties.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
