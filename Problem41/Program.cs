using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem41
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PandigitalPrime(50000000));
            Console.ReadLine();
        }
        public static int PandigitalPrime(int n)
        {
            int largest = 0;
            List<int[]> numberlist = new List<int[]>();
            for(int i=0;i<10;i++)
            {
                int[] array = new int[i];
                for(int j=0;j<array.Length;j++)
                {
                    array[j] = j + 1;
                }
                numberlist.Add(array);
            }
            List<int> primelist = GeneratePrimesSieveOfEratosthenes(n);
            for(int i=0;i<primelist.Count;i++)
            {
                int[] digits = primelist[i].ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();
                int[] numbers = numberlist[digits.Count()];

                var intersect = numbers.Except(digits);
                if (intersect.Count() == 0)
                {
                    Console.WriteLine( primelist[i]);
                    largest = primelist[i]; 
                }
                
            }
           
            return largest;

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
