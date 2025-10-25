using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azure.Api.Generator.CodeGeneration;

internal sealed class RequestGenerator(List<ParameterGenerator> parameterGenerators, RequestBodyGenerator bodyGenerator)
{
    internal SourceCode GenerateRequestClass(string @namespace, string path)
    {
        return new SourceCode($"{path}/Request.g.cs",
            $$"""
                #nullable enable
                using Corvus.Json;
                
                namespace {{@namespace}};
                
                internal partial class Request
                {
                    internal required HttpContext HttpContext { get; init; }
              
                    {{parameterGenerators.Aggregate(new StringBuilder(),(builder, generator) => 
                        builder.AppendLine(generator.GenerateRequestProperty()))}}

                    {{bodyGenerator.GenerateRequestProperty("Body")}}
                    
                    public static Request Bind(HttpContext context)
                    {
                        var request = context.Request;
                        return new Request
                        {
                            HttpContext = context,
                            {{parameterGenerators.Aggregate(new StringBuilder(),(builder, generator) => 
                                builder.AppendLine(generator.GenerateRequestBindingDirective()))}}
                                
                            {{bodyGenerator.GenerateRequestBindingDirective("Body")}}
                        };
                    }
                }
                #nullable restore
              """);
    }
}