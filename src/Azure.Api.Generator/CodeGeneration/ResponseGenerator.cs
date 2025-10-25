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
                #nullable enable
                using Corvus.Json;
                using System.Text.Json;
              
                namespace {{@namespace}};
                
                internal abstract partial class Response
                {
                    internal abstract void WriteTo(HttpResponse httpResponse);
                
                    {{responseBodyGenerators.AggregateToString(generator => 
                        generator.GenerateResponseContentClass())}}
                }
                #nullable restore
              """);
    }
}