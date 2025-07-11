using Azure.Api.Generator.Extensions;
using Microsoft.OpenApi.Models;

namespace Azure.Api.Generator.CodeGeneration;

internal sealed class ParameterGenerator(string @namespace, OpenApiParameter parameter)
{
    internal string FullyQualifiedTypeName =>
        $"{FullyQualifiedTypeDeclarationIdentifier}{(parameter.Required ? "" : "?")}";

    internal string FullyQualifiedTypeDeclarationIdentifier =>
        $"{@namespace}.{TypeDeclarationIdentifier}";
    internal string TypeDeclarationIdentifier { get; } =
        parameter.Name.ToPascalCase() + parameter.In.ToString().ToPascalCase();
    
    private readonly string _propertyName = parameter.Name.ToPascalCase();
    
    internal string GenerateRequestProperty()
    {
        return $$"""
                internal {{(parameter.Required ? "required " : "")}}{{FullyQualifiedTypeName}} {{_propertyName}} { get; init; }
                """;
    }

    internal string GenerateRequestBindingDirective()
    {
        return $$"""
                 {{_propertyName}} = 
                     request.Bind<{{FullyQualifiedTypeName.TrimEnd('?')}}>(
                        "{{parameter.In}}",
                        "{{parameter.Name}}",
                        {{parameter.Required.ToString().ToLower()}}){{(parameter.Required ? "" : ".AsOptional()")}},
                 """;
    }
}