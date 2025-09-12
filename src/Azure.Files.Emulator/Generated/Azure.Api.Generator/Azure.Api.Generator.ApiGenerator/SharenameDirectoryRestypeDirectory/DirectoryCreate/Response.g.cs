using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace ShareNameDirectoryRestypeDirectory.DirectoryCreate;
internal abstract partial class Response
{
    internal sealed class Created201 : Response
    {
        internal Corvus.Json.JsonAny ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal ShareNameDirectoryRestypeDirectory.DirectoryCreate.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
