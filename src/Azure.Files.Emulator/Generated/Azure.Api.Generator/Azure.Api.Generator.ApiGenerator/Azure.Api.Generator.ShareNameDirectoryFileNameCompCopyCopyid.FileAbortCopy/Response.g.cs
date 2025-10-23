using Corvus.Json;

namespace Azure.Files.Emulator.ShareNameDirectoryFileNameCompCopyCopyid.FileAbortCopy;
internal abstract partial class Response
{
    internal sealed class NoContent204 : Response
    {
        internal Corvus.Json.JsonAny ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal Azure.Files.Emulator.ShareNameDirectoryFileNameCompCopyCopyid.FileAbortCopy.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
