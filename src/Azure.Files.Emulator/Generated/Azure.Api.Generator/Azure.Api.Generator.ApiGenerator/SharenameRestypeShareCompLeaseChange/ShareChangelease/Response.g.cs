using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace ShareNameRestypeShareCompLeaseChange.ShareChangeLease;
internal abstract partial class Response
{
    internal sealed class OK200 : Response
    {
        internal Corvus.Json.JsonAny ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal ShareNameRestypeShareCompLeaseChange.ShareChangeLease.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
