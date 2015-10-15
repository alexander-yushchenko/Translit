using System.Collections.Generic;
using System.Linq;

namespace AY.Translit
{
    internal static class Extensions
    {
        internal static string FirstCharToUpper(this string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return input;

            var chars = input.ToCharArray();
            chars[0] = char.ToUpperInvariant(chars[0]);
            return new string(chars);
        }

        internal static string AllCharsToUpper(this string input)
        {
            return string.IsNullOrWhiteSpace(input) ? input : input.ToUpperInvariant();
        }

        internal static IDictionary<string, string> FirstCharToUpper(this IDictionary<string, string> input)
        {
            if (input == null || input.Count == 0) return input;

            var dictionary = input.ToDictionary(
                d => d.Key.FirstCharToUpper(), 
                d => d.Value.FirstCharToUpper());
            return dictionary;
        }

        internal static IDictionary<string, string> AllCharsToUpper(this IDictionary<string, string> input)
        {
            if (input == null || input.Count == 0) return input;

            var dictionary = input.ToDictionary(
                d => d.Key.AllCharsToUpper(),
                d => d.Value.AllCharsToUpper());
            return dictionary;
        }
    }
}
