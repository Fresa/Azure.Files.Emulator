using System.Collections.Generic;
using System.Linq;
using Azure.Api.Generator.Extensions;

namespace Azure.Api.Generator.CodeGeneration;

internal sealed class ResponseGenerator(List<ResponseContentGenerator> responseBodyGenerators)
{
    public SourceCode GenerateResponseClass(string @namespace, string path)
    {
        return new SourceCode($"{path}/Response.g.cs",
            $$"""
                using Corvus.Json;
                
                namespace {{@namespace}};
                
                internal abstract partial class Response
                {
                    {{responseBodyGenerators.AggregateToString(generator => generator.GenerateResponseContentClass())}}
                }
              """);
    }
}