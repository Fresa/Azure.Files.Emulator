using Azure.Api.Generator.Extensions;
using Corvus.Json.CodeGeneration;
using Corvus.Json.CodeGeneration.CSharp;

namespace Azure.Api.Generator.CodeGeneration;

internal sealed class RequestBodyContentGenerator(string contentType, TypeDeclaration typeDeclaration)
{
    private string FullyQualifiedTypeName =>
        $"{FullyQualifiedTypeDeclarationIdentifier}?";

    private string FullyQualifiedTypeDeclarationIdentifier => typeDeclaration.FullyQualifiedDotnetTypeName();

    private readonly string _propertyName = contentType.ToPascalCase();

    internal string ContentType => contentType;
    
    internal string GenerateRequestBindingDirective()
    {
        return $"""
                 {_propertyName} = 
                    request.BindBody<{FullyQualifiedTypeDeclarationIdentifier}>().AsOptional();
                """;
    }
                 
    public string GenerateRequestProperty()
    {
        return $$"""
                 internal {{FullyQualifiedTypeName}} {{_propertyName}} { get; private set; }
                 """;
    }
}