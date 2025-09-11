using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace ShareNameDirectoryFileName.FileDelete;
internal abstract partial class Response
{
    internal sealed class Content202 : Response
    {
    }

    internal sealed class ContentDefault : Response
    {
    }
}
