using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace Azure.Api.Generator;

internal sealed class EndpointGenerator(Compilation compilation)
{
    private readonly List<(string Namespace, string Path)> _missingHandlers = [];

    internal SourceCode Generate(string @namespace, string pathTemplate, string method)
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
              }
              """;
        
        var path = @namespace.Replace('.', '/');
        var found = compilation.GetSymbolsWithName("Operation", SymbolFilter.Type)
            .OfType<INamedTypeSymbol>()
            .Where(symbol => symbol.ContainingNamespace.ToDisplayString() == @namespace)
            .Any(HasHandleMethod);
        if (!found)
        {
            _missingHandlers.Add((@namespace, path));
        }
        
        return new SourceCode(
            $"{path}/Operation.g.cs",
            endpointSource);
    }

    private const string HandleMethodSignature =
        "internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken)";
    private static bool HasHandleMethod(INamedTypeSymbol? typeSymbol) =>
        typeSymbol?.GetMembers("HandleAsync")
            .OfType<IMethodSymbol>()
            .Any(method =>
                method.Parameters.Length == 2 &&
                //method.PartialImplementationPart != null &&
                method.DeclaringSyntaxReferences.Any(reference =>
                {
                    var syntax = reference.GetSyntax() as MethodDeclarationSyntax;
                    return syntax?.Body != null || syntax?.ExpressionBody != null;
                }) &&
                method.Parameters[0].Type.ToDisplayString() == "Request" &&
                method.Parameters[1].Type.ToDisplayString() == "CancellationToken") ?? false;

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