using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace ShareNameDirectoryFileName.FileDownload;
internal abstract partial class Response
{
    internal sealed class Content200 : Response
    {
    }

    internal sealed class Content206 : Response
    {
    }

    internal sealed class ContentDefault : Response
    {
    }
}
