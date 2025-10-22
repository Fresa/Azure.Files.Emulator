using Corvus.Json;

namespace ShareNameDirectoryRestypeDirectoryCompMetadata.DirectorySetMetadata;
internal abstract partial class Response
{
    internal sealed class OK200 : Response
    {
        internal Corvus.Json.JsonAny ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal ShareNameDirectoryRestypeDirectoryCompMetadata.DirectorySetMetadata.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
