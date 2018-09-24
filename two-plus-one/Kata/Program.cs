using System;
using System.Linq;

namespace Kata
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var basket = new[] { 26.14m, 20.94m, 0.71m, 4.3m, 37.55m, 26.04m, 19.88m, 43.49m, 17.89m, 36.8m, 30.71m, 18.83m, 33.88m, 9.7m, 16.78m };
            var basket = new[] { decimal.MaxValue, 2m, 3m };
            var result = Program.Compute(basket);
            // 243.33m expected pay sum
        }

        public static decimal Compute(decimal[] basket)
        {
            if (basket.Any(cost => cost < 0)) throw new ArgumentOutOfRangeException();
            if (basket.Length % 3 != 0) throw new ArgumentException("Input array must have multiple 3 length");

            return basket.OrderBy(_ => _)                       /* Sort expensive to cheapest. */
                         .Where((_, index) => index % 3 != 0)   /* Keep the items customer must pay for. */
                         .Sum();
        }
    }
}
