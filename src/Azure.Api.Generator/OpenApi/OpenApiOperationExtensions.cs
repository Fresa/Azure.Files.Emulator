using System.Collections.Generic;
using Microsoft.OpenApi;

namespace Azure.Api.Generator.OpenApi;

internal static class OpenApiOperationExtensions
{
    internal static IList<IOpenApiParameter> GetParameters(this OpenApiOperation operation) =>
        operation.Parameters ?? [];
}