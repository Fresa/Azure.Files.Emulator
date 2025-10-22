using Corvus.Json;

namespace ShareNameDirectoryRestypeDirectory.DirectoryGetProperties;
internal abstract partial class Response
{
    internal sealed class OK200 : Response
    {
        internal Corvus.Json.JsonAny ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal ShareNameDirectoryRestypeDirectory.DirectoryGetProperties.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
