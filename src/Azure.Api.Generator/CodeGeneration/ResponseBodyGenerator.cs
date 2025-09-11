using System;
using System.Collections.Generic;

namespace Azure.Api.Generator.CodeGeneration;

internal sealed class ResponseBodyGenerator
{
    private readonly string _statusCodePattern;
    private readonly List<ResponseBodyContentGenerator>? _contentGenerators = [];

    private ResponseBodyGenerator(string statusCodePattern)
    {
        _statusCodePattern = statusCodePattern;
    }
    public ResponseBodyGenerator(
        string statusCodePattern,
        List<ResponseBodyContentGenerator> contentGenerators)
    {
        _statusCodePattern = statusCodePattern;
        _contentGenerators = contentGenerators;
    }

    internal static ResponseBodyGenerator Any(string statusCodePattern) => new(statusCodePattern);
    
    public string GenerateResponseMethod()
    {
        throw new NotImplementedException();
    }
}