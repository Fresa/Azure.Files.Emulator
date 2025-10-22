using Corvus.Json;

namespace ShareNameRestypeShareCompStats.ShareGetStatistics;
internal abstract partial class Response
{
    internal sealed class OK200 : Response
    {
        internal ShareNameRestypeShareCompStats.ShareGetStatistics.Content._200.ApplicationXml ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal ShareNameRestypeShareCompStats.ShareGetStatistics.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
