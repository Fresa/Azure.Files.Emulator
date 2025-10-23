using Corvus.Json;

namespace Azure.Files.Emulator.ShareNameRestypeShareCompFilepermission.ShareGetPermission;
internal abstract partial class Response
{
    internal sealed class OK200 : Response
    {
        internal Azure.Files.Emulator.ShareNameRestypeShareCompFilepermission.ShareGetPermission.Content._200.ApplicationJson ApplicationJson { get; set; }
    }

    internal sealed class Default : Response
    {
        internal Azure.Files.Emulator.ShareNameRestypeShareCompFilepermission.ShareGetPermission.Content._Default.ApplicationJson ApplicationJson { get; set; }
    }
}
