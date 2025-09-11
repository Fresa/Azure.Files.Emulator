using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace ShareNameDirectoryFileName.FileDownload;
internal abstract partial class Response
{
    internal sealed class Response200 : Response
    {
    }

    internal sealed class Response206 : Response
    {
    }

    internal sealed class ResponseDefault : Response
    {
    }
}
