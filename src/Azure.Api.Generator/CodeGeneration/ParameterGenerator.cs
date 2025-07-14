using Azure.Api.Generator.Extensions;
using Corvus.Json.CodeGeneration;
using Corvus.Json.CodeGeneration.CSharp;
using Microsoft.OpenApi.Models;

namespace Azure.Api.Generator.CodeGeneration;

internal sealed class ParameterGenerator(TypeDeclaration typeDeclaration, OpenApiParameter parameter)
{
    private string FullyQualifiedTypeName =>
        $"{FullyQualifiedTypeDeclarationIdentifier}{(parameter.Required ? "" : "?")}";

    private string FullyQualifiedTypeDeclarationIdentifier => typeDeclaration.FullyQualifiedDotnetTypeName();
    
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