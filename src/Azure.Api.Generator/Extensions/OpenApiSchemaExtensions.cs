using System.IO;
using Microsoft.OpenApi;

namespace Azure.Api.Generator.Extensions;

internal static class OpenApiSchemaExtensions
{
    internal static string SerializeToJson(this IOpenApiSchema schema)
    {
        using var schemaWriter = new StringWriter();
        var openApiSchemaWriter = new OpenApiJsonWriter(schemaWriter, new OpenApiWriterSettings
        {
            InlineLocalReferences = true
        });
        schema.SerializeAsV2(openApiSchemaWriter);
        return schemaWriter.ToString();
    }
}