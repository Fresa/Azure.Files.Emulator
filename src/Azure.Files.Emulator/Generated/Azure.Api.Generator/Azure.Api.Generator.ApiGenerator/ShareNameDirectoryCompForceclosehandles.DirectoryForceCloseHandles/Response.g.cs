using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace ShareNameDirectoryCompForceclosehandles.DirectoryForceCloseHandles;
internal abstract partial class Response
{
    internal sealed class OK200 : Response
    {
        internal Corvus.Json.JsonAny ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal ShareNameDirectoryCompForceclosehandles.DirectoryForceCloseHandles.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
