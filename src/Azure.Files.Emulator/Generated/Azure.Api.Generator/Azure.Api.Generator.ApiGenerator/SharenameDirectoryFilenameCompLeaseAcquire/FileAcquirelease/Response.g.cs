using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace ShareNameDirectoryFileNameCompLeaseAcquire.FileAcquireLease;
internal abstract partial class Response
{
    internal sealed class Content201 : Response
    {
    }

    internal sealed class ContentDefault : Response
    {
    }
}
