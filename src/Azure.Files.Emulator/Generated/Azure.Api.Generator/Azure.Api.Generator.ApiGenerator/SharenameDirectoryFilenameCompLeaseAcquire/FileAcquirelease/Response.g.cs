using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace ShareNameDirectoryFileNameCompLeaseAcquire.FileAcquireLease;
internal abstract partial class Response
{
    internal sealed class Response201 : Response
    {
    }

    internal sealed class ResponseDefault : Response
    {
    }
}
