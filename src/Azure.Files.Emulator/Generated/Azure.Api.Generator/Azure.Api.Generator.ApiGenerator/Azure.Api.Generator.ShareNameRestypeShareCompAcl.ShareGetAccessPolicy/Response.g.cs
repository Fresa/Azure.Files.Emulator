using Corvus.Json;

namespace Azure.Files.Emulator.ShareNameRestypeShareCompAcl.ShareGetAccessPolicy;
internal abstract partial class Response
{
    internal sealed class OK200 : Response
    {
        internal Azure.Files.Emulator.ShareNameRestypeShareCompAcl.ShareGetAccessPolicy.Content._200.ApplicationXml ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal Azure.Files.Emulator.ShareNameRestypeShareCompAcl.ShareGetAccessPolicy.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
