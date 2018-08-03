using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem47
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DistinctPrimeFactor(4));
            Console.ReadLine();
        }
        public static int DistinctPrimeFactor(int n)
        {
            int num = 0;
            int consecutive = 1;
            List<int> primes = GeneratePrimesSieveOfEratosthenes(1000000);
            int i = 2;
            while(num==0)
            {
                List<int> DistinctPrimes = DistinctPrimeFactors(i, primes);
                if(DistinctPrimes.Count()>=n)
                {
                    if (consecutive >= n)
                    {
                        num = i-consecutive+1;
                        Console.WriteLine(String.Join(";", DistinctPrimes.ToArray()));
                    }
                    else
                    {
                        consecutive++;
                    }
                }
                else
                {
                    consecutive = 1;
                }
                i++;
            }
            return num;
        }
        public static List<int> DistinctPrimeFactors(int n, List<int> primes)
        {
            List<int> Distinct = new List<int>();
            int i = 0;
            while (n>1)
            {
                
                if (n % primes[i] == 0)
                {
                    if(!Distinct.Contains(primes[i]))
                    {
                        Distinct.Add(primes[i]);
                    }
                    n /= primes[i];
                    i = 0;
                }
                else
                {
                    i++;
                }
            }
            return Distinct;
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
