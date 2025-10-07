using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace ShareNameRestypeShareCompAcl.ShareGetAccessPolicy;
internal abstract partial class Response
{
    internal sealed class OK200 : Response
    {
        internal ShareNameRestypeShareCompAcl.ShareGetAccessPolicy.Content._200.ApplicationXml ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal ShareNameRestypeShareCompAcl.ShareGetAccessPolicy.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
