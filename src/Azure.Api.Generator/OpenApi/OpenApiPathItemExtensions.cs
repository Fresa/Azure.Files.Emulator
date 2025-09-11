using System.Collections.Generic;
using System.Net.Http;
using Microsoft.OpenApi;

namespace Azure.Api.Generator.OpenApi;

internal static class OpenApiPathItemExtensions
{
    internal static Dictionary<HttpMethod, OpenApiOperation> GetOperations(this IOpenApiPathItem pathItem) =>
        pathItem.Operations ?? [];
}