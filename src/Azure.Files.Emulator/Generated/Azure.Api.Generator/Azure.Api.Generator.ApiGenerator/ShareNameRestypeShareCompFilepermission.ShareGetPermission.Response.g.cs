#nullable enable
using Corvus.Json;
using System.Text.Json;

namespace Azure.Files.Emulator.ShareNameRestypeShareCompFilepermission.ShareGetPermission;
internal abstract partial class Response
{
    internal abstract void WriteTo(HttpResponse httpResponse);
    internal sealed class OK200 : Response
    {
        public OK200(Azure.Files.Emulator.ShareNameRestypeShareCompFilepermission.ShareGetPermission.Responses._200.ApplicationJson applicationJson)
        {
            ApplicationJson = applicationJson;
        }

        internal Azure.Files.Emulator.ShareNameRestypeShareCompFilepermission.ShareGetPermission.Responses._200.ApplicationJson? ApplicationJson { get; set; }

        internal override void WriteTo(HttpResponse httpResponse)
        {
            IJsonValue content = true switch
            {
                _ when ApplicationJson is not null => ApplicationJson!,
                _ => throw new InvalidOperationException("No content was defined")};
            using var jsonWriter = new Utf8JsonWriter(httpResponse.BodyWriter);
            content.WriteTo(jsonWriter);
        }
    }

    internal sealed class Default : Response
    {
        public Default(Azure.Files.Emulator.ShareNameRestypeShareCompFilepermission.ShareGetPermission.Responses._Default.ApplicationJson applicationJson)
        {
            ApplicationJson = applicationJson;
        }

        internal Azure.Files.Emulator.ShareNameRestypeShareCompFilepermission.ShareGetPermission.Responses._Default.ApplicationJson? ApplicationJson { get; set; }

        internal override void WriteTo(HttpResponse httpResponse)
        {
            IJsonValue content = true switch
            {
                _ when ApplicationJson is not null => ApplicationJson!,
                _ => throw new InvalidOperationException("No content was defined")};
            using var jsonWriter = new Utf8JsonWriter(httpResponse.BodyWriter);
            content.WriteTo(jsonWriter);
        }
    }
}
#nullable restore

