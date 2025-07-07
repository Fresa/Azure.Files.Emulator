using System;
using System.Linq;

namespace Azure.Api.Generator.Extensions;

internal static class StringExtensions
{
    private static readonly char[] DefaultDelimiters = ['/', '?', '=', '&', '{', '}', '-', '_'];
    public static string ToPascalCase(this string str, params char[] delimiters)
    {
        if (string.IsNullOrEmpty(str))
        {
            return str;
        }

        if (delimiters.Length == 0)
        {
            delimiters = DefaultDelimiters;
        }
        
        var sections = str
            .ToLower()
            .Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
            .Select(section => section.First().ToString().ToUpper() + string.Join(string.Empty, section.Skip(1)));

        return string.Concat(sections);
    }
}