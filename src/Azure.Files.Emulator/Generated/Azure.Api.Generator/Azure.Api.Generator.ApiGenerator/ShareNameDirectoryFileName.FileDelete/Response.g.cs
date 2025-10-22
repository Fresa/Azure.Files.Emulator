using Corvus.Json;

namespace ShareNameDirectoryFileName.FileDelete;
internal abstract partial class Response
{
    internal sealed class Accepted202 : Response
    {
        internal Corvus.Json.JsonAny ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal ShareNameDirectoryFileName.FileDelete.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
