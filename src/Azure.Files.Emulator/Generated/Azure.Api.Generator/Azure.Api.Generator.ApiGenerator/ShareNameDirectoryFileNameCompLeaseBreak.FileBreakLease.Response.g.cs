using Corvus.Json;

namespace Azure.Files.Emulator.ShareNameDirectoryFileNameCompLeaseBreak.FileBreakLease;
internal abstract partial class Response
{
    internal sealed class Accepted202 : Response
    {
        internal Corvus.Json.JsonAny ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal Azure.Files.Emulator.ShareNameDirectoryFileNameCompLeaseBreak.FileBreakLease.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
