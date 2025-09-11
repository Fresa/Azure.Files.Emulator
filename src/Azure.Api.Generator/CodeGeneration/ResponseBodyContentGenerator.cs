using System;
using Corvus.Json.CodeGeneration;

namespace Azure.Api.Generator.CodeGeneration;

internal sealed class ResponseBodyContentGenerator(string contentType, TypeDeclaration typeDeclaration)
{
    private readonly TypeDeclaration _typeDeclaration = typeDeclaration;
    internal string ContentType => contentType;
    
    public string GenerateMethod()
    {
        throw new NotImplementedException();
    }
}
