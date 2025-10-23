using Corvus.Json;

namespace Azure.Files.Emulator.ShareNameDirectoryFileNameCompRangelist.FileGetRangeList;
internal abstract partial class Response
{
    internal sealed class OK200 : Response
    {
        internal Azure.Files.Emulator.ShareNameDirectoryFileNameCompRangelist.FileGetRangeList.Content._200.ApplicationXml ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal Azure.Files.Emulator.ShareNameDirectoryFileNameCompRangelist.FileGetRangeList.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
