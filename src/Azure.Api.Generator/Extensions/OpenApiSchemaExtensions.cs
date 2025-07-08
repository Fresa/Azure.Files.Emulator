using System.IO;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Writers;

namespace Azure.Api.Generator.Extensions;

internal static class OpenApiSchemaExtensions
{
    internal static string SerializeToJson(this OpenApiSchema schema)
    {
        using var schemaWriter = new StringWriter();
        var openApiSchemaWriter = new OpenApiJsonWriter(schemaWriter);
        schema.SerializeAsV2WithoutReference(
            openApiSchemaWriter);
        return schemaWriter.ToString();
    }
}