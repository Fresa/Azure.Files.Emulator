using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace ShareNameDirectoryFileName.FileDownload;
internal abstract partial class Response
{
    internal sealed class OK200 : Response
    {
    }

    internal sealed class PartialContent206 : Response
    {
    }

    internal sealed class Default : Response
    {
    }
}
