using System;
using System.Linq;

namespace Kata
{
    public class Program
    {
        static void Main(string[] args)
        {
        }

        //// Traditional solution, did not know that Enumerable.Range existed.
        //public static int Solution(int value)
        //{
        //    int sum = 0;

        //    for (int i = 0; i < value; i += 3)
        //    {
        //        sum += i;
        //    }

        //    for (int i = 0; i < value; i += 5)
        //    {
        //        // if divisible by 3 then we have already added this above
        //        if (i % 3 == 0) continue;
        //        sum += i;
        //    }

        //    return sum;
        //}

        //A nice someone else did!
        //public static int Solution(int value) => Enumerable.Range(0, value)
        //                                                   .Where(n => n % 3 == 0 || n % 5 == 0)
        //                                                   .Sum();


        // And then ofc the intended solution!
        // Modified from Oleksandr_Alieiev solution. Made sum a Func<> and added comments
        public static int Solution(int value)
        {
            // Formula for arithmetic sequence of 1..n where each step is of size 1.
            Func<int, int> Sum = n => (n * (n + 1)) / 2;
            // to get the sum for any stepsize m, we can see that each value in the series 1..n will be increased by m.
            // so Sum(n) * m is how we get the value for an arithmetic sequence for any stepsize.

            int max = value - 1;
            int count3 = max / 3;
            int count5 = max / 5;
            int count15 = max / 15;
            return 3 * Sum(count3) + 5 * Sum(count5) - 15 * Sum(count15);
        }
    }
}
