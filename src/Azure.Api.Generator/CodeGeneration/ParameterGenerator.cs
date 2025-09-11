using System.IO;
using Azure.Api.Generator.Extensions;
using Azure.Api.Generator.OpenApi;
using Corvus.Json.CodeGeneration;
using Corvus.Json.CodeGeneration.CSharp;
using Microsoft.OpenApi;

namespace Azure.Api.Generator.CodeGeneration;

internal sealed class ParameterGenerator(TypeDeclaration typeDeclaration, IOpenApiParameter parameter)
{
    private string FullyQualifiedTypeName =>
        $"{FullyQualifiedTypeDeclarationIdentifier}{(parameter.Required ? "" : "?")}";

    private string FullyQualifiedTypeDeclarationIdentifier => typeDeclaration.FullyQualifiedDotnetTypeName();
    
    private readonly string _propertyName = parameter.GetName().ToPascalCase();
    
    internal string GenerateRequestProperty()
    {
        return $$"""
                internal {{(parameter.Required ? "required " : "")}}{{FullyQualifiedTypeName}} {{_propertyName}} { get; init; }
                """;
    }

    internal string GenerateRequestBindingDirective()
    {
        using var textWriter = new StringWriter();
        var jsonWriter = new OpenApiJsonWriter(textWriter, new OpenApiJsonWriterSettings()
        {
            InlineLocalReferences = true
        });
        parameter.SerializeAsV2(jsonWriter);
        textWriter.Flush();

        return $""""
                 {_propertyName} = 
                    request.Bind<{FullyQualifiedTypeName.TrimEnd('?')}>(
                """
                {textWriter.GetStringBuilder()}
                """
                ){(parameter.Required ? "" : ".AsOptional()")},
                """";
    }
}