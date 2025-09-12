using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace ShareNameDirectoryFileNameCompRename.FileRename;
internal abstract partial class Response
{
    internal sealed class OK200 : Response
    {
        internal Corvus.Json.JsonAny ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal ShareNameDirectoryFileNameCompRename.FileRename.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
