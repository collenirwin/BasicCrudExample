using RegularExtensions;
using System.Collections.Generic;
using System.Linq;

namespace BasicCrud.Utils
{
    public static class StringExtensions
    {
        /// <summary>
        /// Extension wrapper for <see cref="string.Join(string, string[])"/>
        /// </summary>
        /// <param name="values">Collection of string to join</param>
        /// <param name="separator">Separator to put between the joined strings</param>
        /// <returns>A joined string</returns>
        public static string Join(this IEnumerable<string> values, string separator = "")
        {
            return string.Join(separator, values);
        }

        /// <summary>
        /// Capitalizes each word in the given text: hELlO WORld -> Hello World
        /// </summary>
        /// <param name="text">Text to capitalize</param>
        /// <returns>The capitalized text</returns>
        public static string Capitalize(this string text)
        {
            return text.RegexSplit(@"\s+")
                .Select(word => word.Length > 1
                    ? word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower()
                    : word.ToUpper())
                .Join(" ");
        }

        /// <summary>
        /// Normalizes text for database entry:  HelLo   World   -> HELLO WORLD
        /// </summary>
        /// <param name="text">Text to normalize</param>
        /// <returns>The normalized text</returns>
        public static string PrepForDb(this string text)
        {
            return text.RegexReplace(@"\s+", " ").Trim().ToUpper();
        }
    }
}
