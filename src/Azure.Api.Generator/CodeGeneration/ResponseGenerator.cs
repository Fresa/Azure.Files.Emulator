using System.Collections.Generic;
using System.Linq;
using Azure.Api.Generator.Extensions;

namespace Azure.Api.Generator.CodeGeneration;

internal sealed class ResponseGenerator(List<ResponseContentGenerator> responseBodyGenerators)
{
    public static readonly ResponseGenerator Any = new([ResponseContentGenerator.Any()]);

    public string GenerateResponseClass(string @namespace)
    {
        return
            $$"""
                using Azure.Files.Emulator.Http;
                using Corvus.Json;
                
                namespace {{@namespace}};
                
                internal abstract partial class Response
                {
                    {{responseBodyGenerators.AggregateToString(generator => generator.GenerateResponseContent())}}
                }
              """;
    }
}