using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace ShareNameDirectoryFileNameCompLeaseBreak.FileBreakLease;
internal abstract partial class Response
{
    internal sealed class Accepted202 : Response
    {
        internal Corvus.Json.JsonAny ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal ShareNameDirectoryFileNameCompLeaseBreak.FileBreakLease.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
