using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace ShareNameRestypeShare.ShareDelete;
internal abstract partial class Response
{
    internal sealed class Accepted202 : Response
    {
    }

    internal sealed class Default : Response
    {
    }
}
