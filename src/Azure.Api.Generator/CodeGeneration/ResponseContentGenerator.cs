using System;
using System.Collections.Generic;

namespace Azure.Api.Generator.CodeGeneration;

internal sealed class ResponseContentGenerator
{
    private readonly string _statusCodePattern;
    private readonly List<ResponseBodyContentGenerator>? _contentGenerators = [];

    private ResponseContentGenerator(string statusCodePattern)
    {
        _statusCodePattern = statusCodePattern;
    }
    public ResponseContentGenerator(
        string statusCodePattern,
        List<ResponseBodyContentGenerator> contentGenerators)
    {
        _statusCodePattern = statusCodePattern;
        _contentGenerators = contentGenerators;
    }

    internal static ResponseContentGenerator Any(string statusCodePattern = "default") => new(statusCodePattern);
    
    public string GenerateResponseContent()
    {
        return 
            $$"""
            internal sealed class Response{{_statusCodePattern}} : Response
            {
                
            }
            """;
    }
}