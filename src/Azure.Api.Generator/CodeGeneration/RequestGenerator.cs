using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azure.Api.Generator.CodeGeneration;

internal sealed class RequestGenerator(List<ParameterGenerator> parameterGenerators, RequestBodyGenerator bodyGenerator)
{
    internal string GenerateRequestClass(string @namespace)
    {
        return
            $$"""
                #nullable enable
                using OpenApiGenerator;
                using Corvus.Json;
                
                namespace {{@namespace}};
                
                internal partial class Request
                {
                    {{parameterGenerators.Aggregate(new StringBuilder(),(builder, generator) => 
                        builder.AppendLine(generator.GenerateRequestProperty()))}}

                    {{bodyGenerator.GenerateRequestProperty("Body")}}
                                              
                    public static Request Bind(HttpRequest request)
                    {
                        return new Request
                        {
                            {{parameterGenerators.Aggregate(new StringBuilder(),(builder, generator) => 
                                builder.AppendLine(generator.GenerateRequestBindingDirective()))}}
                                
                            {{bodyGenerator.GenerateRequestBindingDirective("Body")}}
                        };
                    }
                }
                #nullable restore
              """;
    }
}