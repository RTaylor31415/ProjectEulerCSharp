using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem37
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(TruncatablePrimes(11));
            Console.ReadLine();
        }
        public static int TruncatablePrimes(int primes)
        {
            int sum = 0;
            int count = 0;
            List<int> primelist = new List<int>();
            primelist = GeneratePrimesSieveOfEratosthenes(1000000);

            int i = 5;
            while (count<11)
            {
                if (isvalid(i, primelist))
                {
                    count++;
                    Console.WriteLine(primelist[i]);
                    sum += primelist[i];
                }
                i++;
            }
            return sum;

        }
        public static bool isvalid(int n,List<int> primelist)
        {
            bool valid = true;
            ArrayList templist = new ArrayList();
            ArrayList list = new ArrayList();
            int temp = primelist[n];
            while (temp > 0)
            {
                templist.Add(temp % 10);
                if (!primelist.Contains(temp))
                {
                    return false;
                }
                temp /= 10;
                
            }
            int temp2 = 0;
            for (int k = 0; k <templist.Count; k++)
            {
                temp2 += (int)templist[k]*(int)Math.Pow(10, k);
                if (!primelist.Contains(temp2))
                {

                    return false;
                    
                }
            }

            return valid;
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
