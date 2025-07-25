﻿using System.IO;
using Azure.Api.Generator.Extensions;
using Corvus.Json.CodeGeneration;
using Corvus.Json.CodeGeneration.CSharp;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Writers;

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
        using var textWriter = new StringWriter();
        var jsonWriter = new OpenApiJsonWriter(textWriter);
        parameter.SerializeAsV2WithoutReference(jsonWriter);
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