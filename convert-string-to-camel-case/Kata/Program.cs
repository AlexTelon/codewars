using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Kata
{
    public class Program
    {
        static void Main(string[] args)
        {
        }

        // The most robust solution that handles weird cases that are really not valid names. But its good to be extra careful
        public static string ToCamelCase(string input)
        {
            if (input == null) throw new ArgumentNullException();

            // Gather the actual words
            var words = input.Split(new char[] { '-', '_' }, StringSplitOptions.RemoveEmptyEntries);

            // Make each word except the first start with a uppercase char
            for (int i = 1; i < words.Length; i++)
            {
                // CultureInfo.CurrentCulture.TextInfo.ToTitleCase removes camelcase from words separated by dashes.
                //words[i] = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(words[i]);
                words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1);
            }

            return string.Concat(words);
        }

        // A Linq alternative
        //public static string ToCamelCase(string input)
        //{
        //    if (input == null) throw new ArgumentNullException();

        //    var words = input.Split(new char[] { '-', '_' }, StringSplitOptions.RemoveEmptyEntries);
        //    if (!words.Any()) return "";

        //    var camelCase = new List<string>() { words.First() };
        //    camelCase.AddRange(words.Skip(1).Select(s => char.ToUpper(s[0]) + s.Substring(1)));
        //    return string.Join("", camelCase);
        //}

        //// A Linq alternative 2
        //public static string ToCamelCase(string input)
        //{
        //    if (input == null) throw new ArgumentNullException();

        //    // Gather the actual words
        //    var words = input.Split(new char[] { '-', '_' }, StringSplitOptions.RemoveEmptyEntries);

        //    return string.Concat(words.Select((item, index) => index == 0 ? item : char.ToUpper(item[0]) + item.Substring(1)));
        //}

        //// Linq using Aggregate, this gets rid of string.Concat
        //public static string ToCamelCase(string input)
        //{
        //    if (input == null) throw new ArgumentNullException();

        //    // Gather the actual words
        //    var words = input.Split(new char[] { '-', '_' }, StringSplitOptions.RemoveEmptyEntries);
        //    if (!words.Any()) return "";

        //    return words.Aggregate((a, b) => a + char.ToUpper(b.First()) + b.Substring(1));
        //}
    }
}
