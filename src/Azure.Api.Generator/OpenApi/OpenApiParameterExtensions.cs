using Azure.Api.Generator.Extensions;
using Microsoft.OpenApi.Models;

namespace Azure.Api.Generator.OpenApi;

internal static class OpenApiParameterExtensions
{
    internal static string GetTypeDeclarationIdentifier(this OpenApiParameter parameter) => 
        parameter.Name.ToPascalCase() + parameter.In.ToString().ToPascalCase();
}