using System.Threading;

namespace SharenameDirectoryRestypeDirectoryCompList.DirectoryListfilesanddirectoriessegment;
internal partial class DirectoryListfilesanddirectoriessegment
{
    internal const string PathTemplate = "/{shareName}/{directory}?restype=directory&comp=list";
    internal const string Method = "DirectoryListfilesanddirectoriessegment";
    internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken);
}
