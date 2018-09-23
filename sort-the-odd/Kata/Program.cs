using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata
{
    public class Program
    {
        static void Main(string[] args)
        {
        }

        //public static int[] SortArray(int[] array)
        //{
        //    if (array == null) throw new ArgumentNullException();

        //    var oddNumbers = array.Where(IsOdd).ToList();
        //    oddNumbers.Sort();
        //    var oddCounter = 0;

        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        if (IsOdd(array[i]))
        //        {
        //            array[i] = oddNumbers[oddCounter++];
        //        }
        //    }

        //    return array;
        //}


        public static int[] SortArray(int[] array)
        {
            Func<int,bool> IsOdd = n => n % 2 == 1;

            var sortedOddNumbers = new Queue<int>(array.Where(IsOdd).OrderBy(n => n));
            return array.Select(n => IsOdd(n) ? sortedOddNumbers.Dequeue() : n).ToArray();
        }

        //public static bool IsOdd(int n) => (n + 1) % 2 == 0;
    }
}
