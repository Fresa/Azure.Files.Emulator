using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace ShareNameDirectoryFileNameCompCopy.FileStartCopy;
internal abstract partial class Response
{
    internal sealed class Accepted202 : Response
    {
        internal Corvus.Json.JsonAny ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal ShareNameDirectoryFileNameCompCopy.FileStartCopy.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
