﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Azure.Api.Generator;

internal sealed class EndpointGenerator(Compilation compilation)
{
    private readonly List<(string Namespace, string Path)> _missingHandlers = [];

    internal SourceCode Generate(string @namespace, string path, string pathTemplate, string method)
    {
        var endpointSource =
            $$"""
              using System.Threading;

              namespace {{@namespace}};

              internal partial class Operation
              {
                internal const string PathTemplate = "{{pathTemplate}}";
                internal const string Method = "{{method}}";

                {{HandleMethodSignature}};
                
                internal static async Task HandleAsync(
                    HttpContext context, 
                    Operation operation, 
                    CancellationToken cancellationToken)
                {
                    var request = Request.Bind(context.Request);
                    var response = await operation.HandleAsync(request, cancellationToken)
                        .ConfigureAwait(false);
                    response.WriteTo(context.Response);
                }
              }
              """;
        
        var hasImplementedHandleMethod = compilation.GetSymbolsWithName("Operation", SymbolFilter.Type)
            .OfType<INamedTypeSymbol>()
            .Where(symbol => symbol.ContainingNamespace.ToDisplayString() == @namespace)
            .Any(HasImplementedHandleMethod);
        if (!hasImplementedHandleMethod)
        {
            _missingHandlers.Add((@namespace, path));
        }
        
        return new SourceCode(
            $"{path}/Operation.g.cs",
            endpointSource);
    }

    private const string HandleMethodSignature =
        "internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken)";

    private static bool HasImplementedHandleMethod(INamedTypeSymbol typeSymbol)
    {
        var members = typeSymbol.GetMembers("HandleAsync");
        return members.OfType<IMethodSymbol>()
            .Any(method =>
                HasImplementation(method) &&
                method.Parameters is [{ Type.Name: "Request" }, { Type.Name: "CancellationToken" }]);
    }

    private static bool HasImplementation(IMethodSymbol method) =>
        !method.IsPartialDefinition || method.PartialImplementationPart != null;

    internal bool TryGenerateMissingHandlers(
        out (SourceCode SourceCode, Diagnostic Diagnostic)[] missingHandlers)
    {
        if (_missingHandlers.Count == 0)
        {
            missingHandlers = [];
            return false;
        }

        missingHandlers =
            _missingHandlers.Select(handler =>
                {
                    var filename = $"{handler.Path}/Operation.Handler.g.cs";
                    return (new SourceCode(
                            filename,
                            GenerateMissingHandler(handler.Namespace)),
                        CreateMissingHandlersDiagnosticMessage(handler.Namespace, filename));
                })
                .ToArray();
        return true;
    }

    private static Diagnostic CreateMissingHandlersDiagnosticMessage(string @namespace, string filePath) =>
        Diagnostic.Create(
            Af1001MissingApiOperationHandler,
            Location.Create(filePath, new TextSpan(), new LinePositionSpan()),
            messageArgs: [@namespace, filePath]);

    private static string GenerateMissingHandler(string @namespace) =>
        $$"""
            namespace {{@namespace}}
            {
                internal partial class Operation
                {
                    {{HandleMethodSignature}}
                    {
                        throw new NotImplementedException();
                    }
                }
            }
          """;

    private static readonly DiagnosticDescriptor Af1001MissingApiOperationHandler =
        new(
            id: "AF1001",
            title: "Missing API operation handlers",
            messageFormat: $"HandleAsync is missing for the {{0}} operation. A generated stub can be copied from {{1}}.",
            category: "Api",
            DiagnosticSeverity.Warning,
            isEnabledByDefault: true);
}