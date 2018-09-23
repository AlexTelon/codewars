using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata
{
    public class Program
    {
        static void Main(string[] args)
        {
            //string derp = String.Concat(Program.UniqueInOrder("\0ab"));
            string derp = String.Concat(Program.UniqueInOrder((IEnumerable<object>)null));

            //UniqueInOrder(new List<object>() { null });
        }

        // A nice and short Linq solution, other users had use something like this and it is interesting
        // though I prefer naming like (item, index) over (n, i) that I often saw others do.
        // Also, I dont know how to best format this for readability
        //public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable) =>
        //    iterable.Where((item, index) => index == 0 ||
        //                                   (index >= 1 && !item.Equals(iterable.ElementAt(index - 1))));


        // A more verbose solution thatn the one above, but also a mroe readable for people who are not used to Linq
        // It is much clearer what happens in the special cases, that the above code also throws an ArgumentNullException is not self-evident for example.

        // However the loop is not as elegant as I would want. I dont like that I had to add the first element to results outside the loop..
        // Using results.LastOrDefault() inside the loop almost works to remove that, but it gives incorrect results when first item in iterable is default(T).

        // Skip(1) is not strictly needed but you can only skip it because the logic happens to work out.
        // So you really should have a comment explaining what you did or somebody is going to copy the code for reuse somewhere and miss that.
        public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
        {
            if (iterable == null) throw new ArgumentNullException(); ;
            if (!iterable.Any()) return Enumerable.Empty<T>();

            var results = new List<T>();
            results.Add(iterable.First());

            foreach (var item in iterable.Skip(1))
            {
                // ignore if same
                if (Object.Equals(results.Last(), item)) continue;

                results.Add(item);
            }
            return results;
        }
    }
}
