using System.Threading;

namespace Azure.Files.Emulator.ShareNameDirectoryFileNameCompMetadata.FileSetMetadata;
internal partial class Operation
{
    internal const string PathTemplate = "/{shareName}/{directory}/{fileName}?comp=metadata";
    internal const string Method = "FileSetMetadata";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
