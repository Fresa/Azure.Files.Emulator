using System.Collections.Generic;

namespace Azure.Api.Generator.CodeGeneration;

internal sealed class ResponseGenerator
{
    private readonly List<ResponseBodyGenerator>? _responseBodyGenerators;

    
    private ResponseGenerator()
    {
        
    }
    public ResponseGenerator(
        List<ResponseBodyGenerator> responseBodyGenerators)
    {
        _responseBodyGenerators = responseBodyGenerators;
    }

    public static ResponseGenerator Empty = new();

    public string GenerateResponseMethods()
    {
        if (_responseBodyGenerators is null)
        {
            return
                """
                internal static Response Any() => new AnyResponse();
                
                internal sealed class AnyResponse : Response
                {
                }
                """;
        }
        return $$"""
                 internal static Response NotImplemented => throw new NotImplementedException();
                 """;
    }
}