using Azure.Api.Generator.Extensions;
using Corvus.Json.CodeGeneration;
using Corvus.Json.CodeGeneration.CSharp;

namespace Azure.Api.Generator.CodeGeneration;

internal sealed class ResponseBodyContentGenerator(string contentType, TypeDeclaration typeDeclaration)
{
    public string GenerateContentProperty()
    {
        return
            $$"""
                internal {{typeDeclaration.FullyQualifiedDotnetTypeName()}} {{contentType.ToPascalCase()}} { get; set; }          
              """; 
    }
}
