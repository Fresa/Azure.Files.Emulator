using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace ShareNameDirectoryFileNameRestypeSymboliclink.FileCreateSymbolicLink;
internal abstract partial class Response
{
    internal sealed class Created201 : Response
    {
    }

    internal sealed class Default : Response
    {
    }
}
