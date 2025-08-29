using Azure.Api.Generator.Extensions;
using Microsoft.OpenApi;

namespace Azure.Api.Generator.OpenApi;

internal static class OpenApiParameterExtensions
{
    internal static string GetTypeDeclarationIdentifier(this IOpenApiParameter parameter) => 
        parameter.Name.ToPascalCase() + parameter.In.ToString().ToPascalCase();
}