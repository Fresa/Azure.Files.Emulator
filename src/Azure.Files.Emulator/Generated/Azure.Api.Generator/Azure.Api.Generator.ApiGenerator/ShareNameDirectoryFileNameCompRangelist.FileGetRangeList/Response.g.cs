using Corvus.Json;

namespace ShareNameDirectoryFileNameCompRangelist.FileGetRangeList;
internal abstract partial class Response
{
    internal sealed class OK200 : Response
    {
        internal ShareNameDirectoryFileNameCompRangelist.FileGetRangeList.Content._200.ApplicationXml ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal ShareNameDirectoryFileNameCompRangelist.FileGetRangeList.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
