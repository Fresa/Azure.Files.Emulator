using Corvus.Json;

namespace ShareNameRestypeShareCompFilepermission.ShareCreatePermission;
internal abstract partial class Response
{
    internal sealed class Created201 : Response
    {
        internal Corvus.Json.JsonAny ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal ShareNameRestypeShareCompFilepermission.ShareCreatePermission.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
