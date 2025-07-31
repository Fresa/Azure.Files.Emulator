using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Azure.Api.Generator;

internal sealed class EndpointGenerator(Compilation compilation)
{
    private readonly List<(string Namespace, string ClassName)> _missingHandlers = [];

    internal SourceCode Generate(string @namespace, string className, string pathTemplate, string method)
    {
        var endpointSource =
            $$"""
              using System.Threading;

              namespace {{@namespace}};

              internal partial class {{className}}
              {
                internal const string PathTemplate = "{{pathTemplate}}";
                internal const string Method = "{{method}}";

                {{HandleMethodSignature}};
              }
              """;
        
        var operationFqtn = $"{@namespace}.{className}";
        if (!HasHandleMethod(compilation.GetTypeByMetadataName(operationFqtn)))
        {
            _missingHandlers.Add((@namespace, className));
        }

        return new SourceCode(
            $"{@namespace.Replace('.', '/')}/Operation.g.cs",
            endpointSource);
    }

    private const string HandleMethodSignature =
        "internal partial Task<Response> HandleAsync(Request request, CancellationToken cancellationToken)";
    private static bool HasHandleMethod(INamedTypeSymbol? typeSymbol) =>
        typeSymbol?.GetMembers("HandleAsync")
            .OfType<IMethodSymbol>()
            .Any(method =>
                method.Parameters.Length == 2 &&
                method.Parameters[0].Type.ToDisplayString() == "Request" &&
                method.Parameters[1].Type.ToDisplayString() == "System.Threading.CancellationToken") ?? false;

    internal bool TryGenerateMissingHandlers(
        [NotNullWhen(true)] out SourceCode? sourceCode)
    {
        if (_missingHandlers.Count == 0)
        {
            sourceCode = null;
            return false;
        }

        var code =
            _missingHandlers
                .Aggregate(new StringBuilder(), (builder, tuple) =>
                    builder.AppendLine(GenerateMissingHandler(tuple.Namespace, tuple.ClassName)))
                .ToString();
        sourceCode = new SourceCode(GeneratedMissingHandlersFileName, code);
        return true;
    }

    internal Diagnostic CreateMissingHandlersDiagnosticMessage() =>
        Diagnostic.Create(
            Af1001MissingApiOperationHandler,
            Location.Create(GeneratedMissingHandlersFileName, new TextSpan(), new LinePositionSpan()),
            messageArgs: [_missingHandlers.Count]);

    private static string GenerateMissingHandler(string @namespace, string className) =>
        $$"""
            namespace {{@namespace}}
            {
                internal partial class {{className}}
                {
                    {{HandleMethodSignature}}
                    {
                        throw new NotImplementedException();
                    }
                }
            }
          """;
    
    private const string GeneratedMissingHandlersFileName = "MissingHandlers.g.cs";

    private static readonly DiagnosticDescriptor Af1001MissingApiOperationHandler =
        new(
            id: "AF1001",
            title: "Missing API operation handlers",
            messageFormat: $"HandleAsync is missing for {{0}} operation(s). Copy the missing handler method signatures and classes from {GeneratedMissingHandlersFileName} and recompile.",
            category: "Api",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);
}