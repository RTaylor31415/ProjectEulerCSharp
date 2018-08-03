using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem72
{
    class Program
    {
        public static List<int> primelist = GeneratePrimesSieveOfEratosthenes(1000000);
        static void Main(string[] args)
        {
            //Console.WriteLine(primefactors(20));
            Stopwatch stopwatch = Stopwatch.StartNew();
            Console.WriteLine(CountingFractions(10000));
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            Console.ReadLine();
        }
        public static double CountingFractions(int n)
        {
            int total = 0;
            for (int i = 1; i <= n; i ++)
            {
                total += relativelyPrime(i);
            }
            return total;
        }
        public static int relativelyPrime(int n)
        {
            int count = 1;
            HashSet<int> factors = primefactors(n);
            for (int i = 2; i < n; i++)
            {
                HashSet<int> tempfactors = primefactors(i);
                var difference = factors.Intersect(tempfactors);
                if (difference.Count() == 0)
                {
                    count++;
                }

            }
            return count;
        }
        public static HashSet<int> primefactors(int n)
        {
            HashSet<int> factors = new HashSet<int>();
            int iterator = 0;
            while (n > 1)
            {
                if (n % primelist[iterator] == 0)
                {
                    factors.Add(primelist[iterator]);
                    n /= primelist[iterator];
                    iterator = 0;
                }
                else
                {
                    iterator++;
                }

            }
            return factors;
        }
        public static int ApproximateNthPrime(int nn)
        {
            double n = (double)nn;
            double p;
            if (nn >= 7022)
            {
                p = n * Math.Log(n) + n * (Math.Log(Math.Log(n)) - 0.9385);
            }
            else if (nn >= 6)
            {
                p = n * Math.Log(n) + n * Math.Log(Math.Log(n));
            }
            else if (nn > 0)
            {
                p = new int[] { 2, 3, 5, 7, 11 }[nn - 1];
            }
            else
            {
                p = 0;
            }
            return (int)p;
        }

        // Find all primes up to and including the limit
        public static BitArray SieveOfEratosthenes(int limit)
        {
            BitArray bits = new BitArray(limit + 1, true);
            bits[0] = false;
            bits[1] = false;
            for (int i = 0; i * i <= limit; i++)
            {
                if (bits[i])
                {
                    for (int j = i * i; j <= limit; j += i)
                    {
                        bits[j] = false;
                    }
                }
            }
            return bits;
        }

        public static List<int> GeneratePrimesSieveOfEratosthenes(int n)
        {
            int limit = ApproximateNthPrime(n);
            BitArray bits = SieveOfEratosthenes(limit);
            List<int> primes = new List<int>();
            for (int i = 0, found = 0; i < limit && found < n; i++)
            {
                if (bits[i])
                {
                    primes.Add(i);
                    found++;
                }
            }
            return primes;
        }
    }
}
