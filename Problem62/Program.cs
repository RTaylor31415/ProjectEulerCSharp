using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Diagnostics;

namespace Problem62
{
    class Program
    {
        static void Main(string[] args)
        {

            Stopwatch stopwatch = Stopwatch.StartNew();
            Console.WriteLine(CubicPermutations(5).ToString());
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            Console.ReadLine();
        }
        public static BigInteger CubicPermutations(int n)
        {
            int count = 0;
            int i = 0;
            List<BigInteger> cubelist = cubes(10000);
            HashSet<BigInteger> hashlist = cubehash(10000);
            List<int[]> cubelistnumbers = new List<int[]>();
            foreach(BigInteger test in cubelist)
            {
                int[] newdigits = test.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();
                cubelistnumbers.Add(newdigits);
            }
            while(count!=n)
            {
                count = 1;
                int[] test = cubelistnumbers[i];
                List<BigInteger> permutecubes = new List<BigInteger>();
                permutecubes.Add(cubelist[i]);
                foreach (int[] permutation in cubelistnumbers)
                {
                    if(permutation.Count()<test.Count())
                    {
                        continue;
                    }
                    else if(permutation.Count() > test.Count())
                    {
                        break;
                    }
                    int[] sortedpermuation = (int[])cubelistnumbers[i].Clone();
                    int[] sortedpermuation2 = (int[])permutation.Clone();
                    Array.Sort(sortedpermuation);
                    Array.Sort(sortedpermuation2);
                    if(sortedpermuation.SequenceEqual(sortedpermuation2))
                    {
                        string num = string.Join("", permutation);
                        BigInteger newnum = 0;
                        BigInteger.TryParse(num, out newnum);
                        if (hashlist.Contains(newnum) && !permutecubes.Contains(newnum))
                        {
                            permutecubes.Add(newnum);
                            count++;
                        }
                    }
                }
                i++;
            }
            return cubelist[i-1];
        }
        public static List<BigInteger> cubes(int n)
        {
            List<BigInteger> cubelist = new List<BigInteger>();
            for (int i = 1; i < n; i++)
            {
                cubelist.Add(BigInteger.Pow(i, 3));
            }
            return cubelist;
        }
        public static HashSet<BigInteger> cubehash(int n)
        {
            HashSet<BigInteger> cubelist = new HashSet<BigInteger>();
            for (int i = 1; i < n; i++)
            {
                cubelist.Add(BigInteger.Pow(i, 3));
            }
            return cubelist;
        }
        public static List<List<T>> GeneratePermutations<T>(List<T> items)
        {
            // Make an array to hold the
            // permutation we are building.
            T[] current_permutation = new T[items.Count];

            // Make an array to tell whether
            // an item is in the current selection.
            bool[] in_selection = new bool[items.Count];

            // Make a result list.
            List<List<T>> results = new List<List<T>>();

            // Build the combinations recursively.
            PermuteItems<T>(items, in_selection,
                current_permutation, results, 0);

            // Return the results.
            return results;
        }
        public static void PermuteItems<T>(List<T> items, bool[] in_selection, T[] current_permutation, List<List<T>> results, int next_position)
        {
            // See if all of the positions are filled.
            if (next_position == items.Count)
            {
                // All of the positioned are filled.
                // Save this permutation.
                results.Add(current_permutation.ToList());
            }
            else
            {
                // Try options for the next position.
                for (int i = 0; i < items.Count; i++)
                {
                    if (!in_selection[i])
                    {
                        // Add this item to the current permutation.
                        in_selection[i] = true;
                        current_permutation[next_position] = items[i];

                        // Recursively fill the remaining positions.
                        PermuteItems<T>(items, in_selection,
                            current_permutation, results,
                            next_position + 1);

                        // Remove the item from the current permutation.
                        in_selection[i] = false;
                    }
                }
            }
        }
    }
}
