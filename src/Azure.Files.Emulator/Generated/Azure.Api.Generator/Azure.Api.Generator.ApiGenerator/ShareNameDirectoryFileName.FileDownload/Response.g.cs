using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace ShareNameDirectoryFileName.FileDownload;
internal abstract partial class Response
{
    internal sealed class OK200 : Response
    {
        internal ShareNameDirectoryFileName.FileDownload.Content._200.ApplicationXml ApplicationXml { get; set; }
    }

    internal sealed class PartialContent206 : Response
    {
        internal ShareNameDirectoryFileName.FileDownload.Content._206.ApplicationXml ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal ShareNameDirectoryFileName.FileDownload.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
