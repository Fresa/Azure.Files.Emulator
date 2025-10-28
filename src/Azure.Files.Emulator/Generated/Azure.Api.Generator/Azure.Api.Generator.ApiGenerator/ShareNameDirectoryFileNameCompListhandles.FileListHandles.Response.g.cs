#nullable enable
using Corvus.Json;
using System.Text.Json;

namespace Azure.Files.Emulator.ShareNameDirectoryFileNameCompListhandles.FileListHandles;
internal abstract partial class Response
{
    internal abstract void WriteTo(HttpResponse httpResponse);
    internal sealed class OK200 : Response
    {
        public OK200(Azure.Files.Emulator.ShareNameDirectoryFileNameCompListhandles.FileListHandles.Responses._200.ApplicationXml applicationXml)
        {
            ApplicationXml = applicationXml;
        }

        internal Azure.Files.Emulator.ShareNameDirectoryFileNameCompListhandles.FileListHandles.Responses._200.ApplicationXml? ApplicationXml { get; set; }

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
        public Default(Azure.Files.Emulator.ShareNameDirectoryFileNameCompListhandles.FileListHandles.Responses._Default.ApplicationXml applicationXml)
        {
            ApplicationXml = applicationXml;
        }

        internal Azure.Files.Emulator.ShareNameDirectoryFileNameCompListhandles.FileListHandles.Responses._Default.ApplicationXml? ApplicationXml { get; set; }

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

