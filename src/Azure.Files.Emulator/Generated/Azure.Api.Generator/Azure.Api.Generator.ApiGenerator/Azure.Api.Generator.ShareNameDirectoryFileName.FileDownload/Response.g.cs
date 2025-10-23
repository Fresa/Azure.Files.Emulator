using Corvus.Json;

namespace Azure.Files.Emulator.ShareNameDirectoryFileName.FileDownload;
internal abstract partial class Response
{
    internal sealed class OK200 : Response
    {
        internal Azure.Files.Emulator.ShareNameDirectoryFileName.FileDownload.Content._200.ApplicationXml ApplicationXml { get; set; }
    }

    internal sealed class PartialContent206 : Response
    {
        internal Azure.Files.Emulator.ShareNameDirectoryFileName.FileDownload.Content._206.ApplicationXml ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal Azure.Files.Emulator.ShareNameDirectoryFileName.FileDownload.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
