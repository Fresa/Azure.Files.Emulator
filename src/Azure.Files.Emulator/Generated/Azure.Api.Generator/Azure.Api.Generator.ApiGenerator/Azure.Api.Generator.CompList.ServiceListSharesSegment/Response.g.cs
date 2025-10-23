using Corvus.Json;

namespace Azure.Files.Emulator.CompList.ServiceListSharesSegment;
internal abstract partial class Response
{
    internal sealed class OK200 : Response
    {
        internal Azure.Files.Emulator.CompList.ServiceListSharesSegment.Content._200.ApplicationXml ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal Azure.Files.Emulator.CompList.ServiceListSharesSegment.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
