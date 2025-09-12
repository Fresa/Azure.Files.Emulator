using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace ShareNameDirectoryFileNameCompCopyCopyid.FileAbortCopy;
internal abstract partial class Response
{
    internal sealed class NoContent204 : Response
    {
    }

    internal sealed class Default : Response
    {
    }
}
