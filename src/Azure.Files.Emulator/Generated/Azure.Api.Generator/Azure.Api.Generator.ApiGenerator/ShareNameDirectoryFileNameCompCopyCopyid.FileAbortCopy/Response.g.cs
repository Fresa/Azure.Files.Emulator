using Corvus.Json;

namespace ShareNameDirectoryFileNameCompCopyCopyid.FileAbortCopy;
internal abstract partial class Response
{
    internal sealed class NoContent204 : Response
    {
        internal Corvus.Json.JsonAny ApplicationXml { get; set; }
    }

    internal sealed class Default : Response
    {
        internal ShareNameDirectoryFileNameCompCopyCopyid.FileAbortCopy.Content._Default.ApplicationXml ApplicationXml { get; set; }
    }
}
