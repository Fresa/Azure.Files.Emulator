using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace ShareNameDirectoryRestypeDirectory.DirectoryCreate;
internal abstract partial class Response
{
    internal sealed class Created201 : Response
    {
    }

    internal sealed class Default : Response
    {
    }
}
