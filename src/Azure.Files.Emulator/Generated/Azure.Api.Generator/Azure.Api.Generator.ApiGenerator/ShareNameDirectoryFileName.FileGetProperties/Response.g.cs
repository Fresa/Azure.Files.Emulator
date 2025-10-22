using Corvus.Json;

namespace ShareNameDirectoryFileName.FileGetProperties;
internal abstract partial class Response
{
    internal sealed class OK200 : Response
    {
        internal Corvus.Json.JsonAny ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal ShareNameDirectoryFileName.FileGetProperties.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
