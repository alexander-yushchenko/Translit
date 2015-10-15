using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AY.Translit
{
    internal class UkrainianTranslitProcessor : ITranslitProcessor
    {
        private static readonly IDictionary<string, string> SingleLettersDictionary = new Dictionary<string, string>
        {
            {"а", "a"}, {"б", "b"}, {"в", "v"}, {"г", "h"}, {"ґ", "g"}, {"д", "d"}, {"е", "e"}, {"з", "z"}, 
            {"и", "y"}, {"і", "i"}, {"к", "k"}, {"л", "l"}, {"м", "m"}, {"н", "n"}, {"о", "o"}, {"п", "p"}, 
            {"р", "r"}, {"с", "s"}, {"т", "t"}, {"у", "u"}, {"ф", "f"}, {"ь", ""}
        };
        
        private static readonly IDictionary<string, string> FirstWordsLetterDictionary = new Dictionary<string, string>
        {
            {"є", "ye"}, {"ї", "yi"}, {"й", "y"}, {"ю", "yu"}, {"я", "ya"}
        };
        
        private static readonly IDictionary<string, string> MultiLettersDictionary = new Dictionary<string, string>
        {
            {"є", "ie"}, {"ж", "zh"}, {"ї", "i"},
            {"й", "i"}, {"х", "kh"}, {"ц", "ts"},
            {"ч", "ch"}, {"ш", "sh"}, {"щ", "shch"},
            {"ю", "iu"}, {"я", "ia"}, {"зг", "zgh"}
        };

        private static readonly IDictionary<string, string> SingleLettersToUpperDictionary = SingleLettersDictionary.AllCharsToUpper();

        private static readonly IDictionary<string, string> FirstWordsLetterFirstCharToUpperDictionary = FirstWordsLetterDictionary.FirstCharToUpper();

        private static readonly IDictionary<string, string> FirstWordsLetterAllCharsToUpperDictionary = FirstWordsLetterDictionary.AllCharsToUpper();

        private static readonly IDictionary<string, string> MultiLettersFirstCharToUpperDictionary = MultiLettersDictionary.FirstCharToUpper();

        private static readonly IDictionary<string, string> MultiLettersAllCharsToUpperDictionary = MultiLettersDictionary.AllCharsToUpper();

        /// <summary>
        /// Транслітерація українського алфавіту латиницею. Постанова КМУ №55 від 27 січня 2010 р.
        /// </summary>
        /// <param name="input">Текст кирилицею</param>
        /// <returns>Текст латиницею згідно правил транслітерації</returns>
        public string Transliterate(string input)
        {
            var output = FirstWordsLetterDictionary.Aggregate(input, (current, dict) =>
                Regex.Replace(current, string.Concat(@"(?<=^|\W|\d|\s)", dict.Key), dict.Value));

            output = FirstWordsLetterFirstCharToUpperDictionary.Aggregate(output, (current, dict) =>
                Regex.Replace(current, string.Concat(@"(?<=^|\W|\d|\s)", dict.Key, @"(?=\p{Ll})"), dict.Value));

            output = FirstWordsLetterAllCharsToUpperDictionary.Aggregate(output, (current, dict) =>
                Regex.Replace(current, string.Concat(@"(?<=^|\W|\d|\s)", dict.Key, @"(?=\p{Lu}|\W|\d)"), dict.Value));

            output = MultiLettersDictionary.Aggregate(output, (current, dict) =>
               Regex.Replace(current, dict.Key, dict.Value));

            output = MultiLettersFirstCharToUpperDictionary.Aggregate(output, (current, dict) =>
               Regex.Replace(current, string.Concat(dict.Key, @"(?=\p{Ll})"), dict.Value));

            output = MultiLettersAllCharsToUpperDictionary.Aggregate(output, (current, dict) =>
                Regex.Replace(current, string.Concat(dict.Key, @"(?=\p{Lu}|\W|\d)"), dict.Value));

            output = SingleLettersDictionary.Aggregate(output, (current, dict) =>
                Regex.Replace(current, dict.Key, dict.Value));

            output = SingleLettersToUpperDictionary.Aggregate(output, (current, dict) =>
                Regex.Replace(current, dict.Key, dict.Value));

            // Apostrophe remover
            output = FirstWordsLetterDictionary.Aggregate(output, (current, dict) =>
                Regex.Replace(current, string.Concat(@"(?<=\w)[’']", @"(?=", dict.Value, ")"), ""));

            output = FirstWordsLetterFirstCharToUpperDictionary.Aggregate(output, (current, dict) =>
                Regex.Replace(current, string.Concat(@"(?<=\w)[’']", @"(?=", dict.Value, ")"), ""));

            output = FirstWordsLetterAllCharsToUpperDictionary.Aggregate(output, (current, dict) =>
                Regex.Replace(current, string.Concat(@"(?<=\w)[’']", @"(?=", dict.Value, ")"), ""));

            return output;
        }
    }
}
