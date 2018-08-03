using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem46
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GoldBach());
            Console.ReadLine();
        }
        public static int GoldBach()
        {
            List<int> squarelist = new List<int>();
            for(int i=1;i<100;i++)
            {
                squarelist.Add(i * i);
            }
            List<int> primelist = GeneratePrimesSieveOfEratosthenes(1000);
            int j = 5;
            while(true)
            {
                if (primelist.Contains(j))
                {
                    j += 2;
                    continue;
                }
                if(Gold(j,squarelist,primelist))
                {
                    j += 2;
                    continue;
                }
                break;
            }
            return j;
        }
        public static bool Gold(int j, List<int> squarelist,List<int> primelist)
        {
            for (int k = 0; k < squarelist.Count; k++)
            {
                for (int l = 0; l < primelist.Count; l++)
                {
                    if (2 * squarelist[k] + primelist[l] == j)
                    {
                        return true;
                    }
                }
            }
            return false;
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
