using System.Collections.Generic;
using System.Net.Http;
using Azure.Api.Generator.Extensions;

namespace Azure.Api.Generator.CodeGeneration;

internal sealed class OperationRouterGenerator(string @namespace)
{
    internal SourceCode ForMinimalApi(List<(string Namespace, HttpMethod HttpMethod)> operations) =>
        new($"{@namespace}/OperationRouter.g.cs",
$$"""
#nullable enable
namespace {{@namespace}};

internal static class OperationRouter
{
    internal static WebApplication MapOperations(this WebApplication app)
    {
        {{operations.AggregateToString(operation => 
            $"""app.MapMethods({operation.Namespace}.Operation.PathTemplate, ["{operation.HttpMethod.Method}"], {operation.Namespace}.Operation.HandleAsync);""")}}
        return app;
    }
    
    internal static WebApplicationBuilder AddOperations(this WebApplicationBuilder builder)
    {
        {{operations.AggregateToString(operation => 
            $"builder.Services.AddScoped<{operation.Namespace}.Operation>();")}}
        return builder;
    }
}
#nullable restore
""");
}