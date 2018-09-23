using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata
{
    public static class Program
    {
        static void Main(string[] args)
        {
        }

        public static string MakeComplement(string dna) => string.Concat(dna.Select(MakeComplement));

        public static char MakeComplement(this char dna)
        {
            switch (dna)
            {
                case 'T': return 'A';
                case 'A': return 'T';
                case 'C': return 'G';
                case 'G': return 'C';
            }
            throw new Exception($"Unknown char {dna}, only ATCG allowed.");
        }
    }
}
