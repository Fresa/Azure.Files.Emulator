using System.Threading;

namespace Azure.Files.Emulator.ShareNameDirectoryFileNameCompCopy.FileStartCopy;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?comp=copy";
    internal const string Method = "FileStartCopy";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
