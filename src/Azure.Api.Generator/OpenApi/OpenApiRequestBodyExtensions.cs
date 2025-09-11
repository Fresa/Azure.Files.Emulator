using System;
using System.Collections.Generic;
using Microsoft.OpenApi;

namespace Azure.Api.Generator.OpenApi;

internal static class OpenApiRequestBodyExtensions
{
    internal static IDictionary<string, OpenApiMediaType> GetContent(this IOpenApiRequestBody requestBody) =>
        requestBody.Content ?? throw new NullReferenceException("Request body content is required");
}