#nullable enable
using Corvus.Json;
using System.Text.Json;

namespace Azure.Files.Emulator.ShareNameDirectoryFileNameCompRangeFromURL.FileUploadRangeFromURL;
internal abstract partial class Response
{
    internal abstract void WriteTo(HttpResponse httpResponse);
    internal sealed class Created201 : Response
    {
        public Created201(Corvus.Json.JsonAny applicationXml)
        {
            ApplicationXml = applicationXml;
        }

        internal Corvus.Json.JsonAny? ApplicationXml { get; set; }

        internal override void WriteTo(HttpResponse httpResponse)
        {
            IJsonValue content = true switch
            {
                _ when ApplicationXml is not null => ApplicationXml!,
                _ => throw new InvalidOperationException("No content was defined")};
            using var jsonWriter = new Utf8JsonWriter(httpResponse.BodyWriter);
            content.WriteTo(jsonWriter);
        }
    }

    internal sealed class Default : Response
    {
        public Default(Azure.Files.Emulator.ShareNameDirectoryFileNameCompRangeFromURL.FileUploadRangeFromURL.Content._Default.ApplicationXml applicationXml)
        {
            ApplicationXml = applicationXml;
        }

        internal Azure.Files.Emulator.ShareNameDirectoryFileNameCompRangeFromURL.FileUploadRangeFromURL.Content._Default.ApplicationXml? ApplicationXml { get; set; }

        internal override void WriteTo(HttpResponse httpResponse)
        {
            IJsonValue content = true switch
            {
                _ when ApplicationXml is not null => ApplicationXml!,
                _ => throw new InvalidOperationException("No content was defined")};
            using var jsonWriter = new Utf8JsonWriter(httpResponse.BodyWriter);
            content.WriteTo(jsonWriter);
        }
    }
}
#nullable restore

