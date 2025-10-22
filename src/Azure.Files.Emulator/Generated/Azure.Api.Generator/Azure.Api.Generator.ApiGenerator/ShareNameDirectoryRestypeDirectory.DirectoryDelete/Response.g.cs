using Corvus.Json;

namespace ShareNameDirectoryRestypeDirectory.DirectoryDelete;
internal abstract partial class Response
{
    internal sealed class Accepted202 : Response
    {
        internal Corvus.Json.JsonAny ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal ShareNameDirectoryRestypeDirectory.DirectoryDelete.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
