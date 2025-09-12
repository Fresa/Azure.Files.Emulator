using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace ShareNameDirectoryFileNameCompLeaseBreak.FileBreakLease;
internal abstract partial class Response
{
    internal sealed class Accepted202 : Response
    {
    }

    internal sealed class Default : Response
    {
    }
}
