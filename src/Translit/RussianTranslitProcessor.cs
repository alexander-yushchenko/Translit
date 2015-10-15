using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AY.Translit
{
    internal class RussianTranslitProcessor : ITranslitProcessor
    {
        private static readonly IDictionary<string, string> SingleLettersDictionary = new Dictionary<string, string>
        {
            {"а", "a"}, {"б", "b"}, {"в", "v"}, {"г", "g"}, {"д", "d"}, {"е", "e"}, {"ё", "e"},
            {"з", "z"}, {"и", "i"}, {"й", "i"}, {"к", "k"}, {"л", "l"}, {"м", "m"}, {"н", "n"},
            {"о", "o"}, {"п", "p"}, {"р", "r"}, {"с", "s"}, {"т", "t"}, {"у", "u"}, {"ф", "f"},
            {"ы", "y"}, {"ь", ""}, {"э", "e"}
        };

        private static readonly IDictionary<string, string> MultiLettersDictionary = new Dictionary<string, string>
        {
            {"ж", "zh"}, {"х", "kh"}, {"ц", "ts"}, {"ч", "ch"}, {"ш", "sh"}, {"щ", "shch"}, {"ъ", "ie"}, {"ю", "iu"}, {"я", "ia"}
        };

        private static readonly IDictionary<string, string> SingleLettersToUpperDictionary = SingleLettersDictionary.AllCharsToUpper();

        private static readonly IDictionary<string, string> MultiLettersFirstCharToUpperDictionary = MultiLettersDictionary.FirstCharToUpper();

        private static readonly IDictionary<string, string> MultiLettersAllCharsToUpperDictionary = MultiLettersDictionary.AllCharsToUpper();

        /// <summary>
        /// Транслитерация русского алфавита латиницей. ICAO Doc 9303 
        /// </summary>
        /// <param name="input">Текст на кириллице</param>
        /// <returns>Текст латиницей согласно правил транслитерации</returns>
        public string Transliterate(string input)
        {
            var output = MultiLettersDictionary.Aggregate(input, (current, dict) =>
               Regex.Replace(current, dict.Key, dict.Value));

            output = MultiLettersFirstCharToUpperDictionary.Aggregate(output, (current, dict) =>
               Regex.Replace(current, string.Concat(dict.Key, @"(?=\p{Ll})"), dict.Value));

            output = MultiLettersAllCharsToUpperDictionary.Aggregate(output, (current, dict) =>
                Regex.Replace(current, string.Concat(dict.Key, @"(?=\p{Lu}|\W|\d)"), dict.Value));

            output = SingleLettersDictionary.Aggregate(output, (current, dict) =>
                Regex.Replace(current, dict.Key, dict.Value));

            output = SingleLettersToUpperDictionary.Aggregate(output, (current, dict) =>
                Regex.Replace(current, dict.Key, dict.Value));

            return output;
        }
    }
}
