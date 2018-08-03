using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem58
{
    class Program
    {
        public static HashSet<int> primes = new HashSet<int>();
        public static HashSet<int> primes2 = new HashSet<int>();

        static void Main(string[] args)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            Console.WriteLine(spiralPrimes());
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            Console.ReadLine();
        }
        public static int spiralPrimes ()
        {
            GeneratePrimesSieveOfEratosthenes(40000000);
            int count = 1;
            int i = 2;
            double primeratio = 1;
            double primescount = 0;
            double nonprimes = 1;
            while (primeratio >0.1)
            { 
                for(int j=0;j< 4;j++)
                {
                    if (primes.Contains(count) || primes2.Contains(count)) 
                    {
                        primescount++;
                    }
                    else
                    {
                        nonprimes++;
                    }
                    primeratio = primescount / (nonprimes+ primescount);
                    count += i;
                    
                }
                i+=2;
            }
            return i-1;
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

        public static HashSet<int> GeneratePrimesSieveOfEratosthenes(int n)
        {
            int limit = ApproximateNthPrime(n);
            BitArray bits = SieveOfEratosthenes(limit);
            for (int i = 0, found = 0; i < limit && found < n; i++)
            {
                if (bits[i])
                {
                    if(primes.Count>23000000)
                    {
                        primes2.Add(i);
                        found++;
                    }
                    else
                    {
                        primes.Add(i);
                        found++;
                    }
                }
            }
            return primes;
        }
    }
}
