using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class Program
    {
        static string newline = Environment.NewLine;

        /// <summary>
        /// Merge all elements in a and b, sorted in descending order.
        /// </summary>
        /// <param name="a">An array of int ascending order.</param>
        /// <param name="b">An array of int ascending order.</param>
        /// <returns>Returns a merged int array of input arrays sorted descending.</returns>
        public static int[] MergeAndReorder(int[] a, int[] b) {

            int[] result = new int[0];

            try
            {
                int len_a = a.Length;
                int len_b = b.Length;
                int len_r = 0;

                result = new int[len_a + len_b];

                while ((len_a != 0) && (len_b != 0))
                {
                    if (a[len_a - 1] >= b[len_b - 1])
                    {
                        result[len_r++] = a[len_a - 1];
                        len_a--;
                    }
                    else
                    {
                        result[len_r++] = b[len_b - 1];
                        len_b--;
                    }
                }

                while (len_a > 0)
                {
                    result[len_r++] = a[(len_a--) - 1];
                }

                while (len_b > 0)
                {
                    result[len_r++] = b[(len_b--) - 1];
                }
            }
            catch (IndexOutOfRangeException e)
            {
                throw e;
            }

            return result;
        }

        /// <summary>
        /// Display the results of testing the <see cref="MergeAndReorder"/> against the standard approach.
        /// <para>Outputs the source arrays (a, b) then the standard approach result and execution time (ms),
        /// followed by <see cref="MergeAndReorder"/> function output and execution time.</para>
        /// <para>The result of the equals shows if <see cref="MergeAndReorder"/> produced the desired result.</para>
        /// </summary>
        /// <param name="title">Title for this test to be displayed.</param>
        /// <param name="a">An array of int ascending order.</param>
        /// <param name="b">An array of int ascending order.</param>
        /// <returns>Returns a merged int array of input arrays sorted descending.</returns>
        public static void Test(String title, int[] a, int[] b)
        {
            Console.WriteLine(title + newline);

            var watch = System.Diagnostics.Stopwatch.StartNew();

            // Built in concatenate and sort
            watch.Start();
            var z = new int[a.Length + b.Length];
            a.CopyTo(z, 0);
            b.CopyTo(z, a.Length);
            Array.Sort(z,
                    new Comparison<int>(
                        (i2, i1) => i1.CompareTo(i2)
                    ));

            watch.Stop();

            if (z.Length < 50)
                Console.WriteLine("\t[{0}]", string.Join(", ", z));

            Console.WriteLine("concat-sort: " + watch.ElapsedMilliseconds +"ms" + newline);

            // Assignment merge and sort
            watch.Restart();

            int[] result = MergeAndReorder(a, b);
            watch.Stop();

            if (result.Length < 50)
                Console.WriteLine("\t[{0}]", string.Join(", ", result));

            Console.WriteLine("assignment: " + watch.ElapsedMilliseconds + "ms" + newline);

            Console.WriteLine("Equals: " + result.SequenceEqual(z) + newline);
        }

        static void Main(string[] args)
        {
            int[] a = new int[5] { 1, 3, 5, 7, 9 };
            int[] b = new int[5] { 2, 4, 6, 8, 10 };

            // Test witha simple [5] [5] array to prove concept
            Test("Simple", a, b);

            // Generate some random numbers arrays for us to test
            int n = 50000; // make it big :)
            int min = 1;
            int max = n;
            Random randNum = new Random();

            int[] c = Enumerable
                .Repeat(0, n)
                .Select(i => randNum.Next(min, max))
                .ToArray();

            int[] d = Enumerable
                .Repeat(0, n)
                .Select(i => randNum.Next(min, max))
                .ToArray();

            Array.Sort(c);
            Array.Sort(d);

            Test("Long ("+ n +")", c, d);

            Console.ReadKey();
        }
    }
}
