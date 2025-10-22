using Corvus.Json;

namespace ShareNameDirectoryFileNameCompLeaseAcquire.FileAcquireLease;
internal abstract partial class Response
{
    internal sealed class Created201 : Response
    {
        internal Corvus.Json.JsonAny ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal ShareNameDirectoryFileNameCompLeaseAcquire.FileAcquireLease.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
