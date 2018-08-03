using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem49
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(primepermutations());
            Console.ReadLine();
        }
        public static string primepermutations()
        {
            List<int> result = new List<int>();
            List<int> primes = GeneratePrimesSieveOfEratosthenes(10000);
            for(int i=168;i<1300;i++)
            {
                for(int j=1000;j<4000;j++)
                {
                    if(IsPermutation(primes[i],primes[i]+j)&&IsPermutation(primes[i],primes[i]+(j*2)))
                    { 
                        if(primes.Contains(primes[i]+j)&&primes.Contains(primes[i]+j*2))
                        {
                            result.Add(primes[i]);
                            result.Add(primes[i]+j);
                            result.Add(primes[i]+j*2);
                        }
                    }
                }
            }
            return String.Join(";", result.ToArray()); 
        }
        public static bool IsPermutation(int i,int j)
        {
            int[] first = i.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();
            int[] second = j.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();
            if(first.Count()!=second.Count())
            {
                return false;
            }
            var intersect = first.Except(second).Union(second.Except(first));
            if(intersect.Count()==0)
            {
                return true;
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
