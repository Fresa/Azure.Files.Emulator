using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Azure.Api.Generator.Extensions;

internal static class StringExtensions
{
    private static readonly char[] DefaultDelimiters = ['/', '?', '=', '&', '{', '}', '-', '_'];
    
    [return: NotNullIfNotNull(nameof(str))]
    public static string? ToPascalCase(this string? str, params char[] delimiters)
    {
        if (str is null or "")
        {
            return str;
        }

        if (delimiters.Length == 0)
        {
            delimiters = DefaultDelimiters;
        }
        
        var sections = str
            .Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
            .Select(section => section.First().ToString().ToUpper() + string.Join(string.Empty, section.Skip(1)));

        return string.Concat(sections);
    }
}