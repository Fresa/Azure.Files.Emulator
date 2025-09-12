using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace CompList.ServiceListSharesSegment;
internal abstract partial class Response
{
    internal sealed class OK200 : Response
    {
        internal CompList.ServiceListSharesSegment.Content._200.ApplicationXml ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal CompList.ServiceListSharesSegment.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
