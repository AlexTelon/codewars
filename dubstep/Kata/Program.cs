using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Kata
{
    public class Program
    {
        static void Main(string[] args)
        {
        }

        public static string SongDecoder(string lyrics)
        {
            // A better solution
            return Regex.Replace(lyrics, "(WUB)+", " ").Trim();

            // typical-me-solution.
            //var words = lyrics.Split("WUB", StringSplitOptions.RemoveEmptyEntries);
            //return string.Join(' ', words).Trim();
        }
    } 
}
