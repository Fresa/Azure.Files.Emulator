using Microsoft.CodeAnalysis;

namespace Azure.Api.Generator.CodeGeneration;

internal sealed class TypeSpecification(string name, string @namespace, AdditionalText schema)
{
    public string Name { get; } = name;
    public string Namespace { get; } = @namespace;
    public AdditionalText Schema { get; } = schema;
}