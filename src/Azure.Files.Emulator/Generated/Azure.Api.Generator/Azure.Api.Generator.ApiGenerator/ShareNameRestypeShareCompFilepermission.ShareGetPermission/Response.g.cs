using Azure.Files.Emulator.Http;
using Corvus.Json;

namespace ShareNameRestypeShareCompFilepermission.ShareGetPermission;
internal abstract partial class Response
{
    internal sealed class OK200 : Response
    {
        internal ShareNameRestypeShareCompFilepermission.ShareGetPermission.Content._200.ApplicationJson ApplicationJson { get; set; }
    }

    internal sealed class Default : Response
    {
        internal ShareNameRestypeShareCompFilepermission.ShareGetPermission.Content._Default.ApplicationJson ApplicationJson { get; set; }
    }
}
