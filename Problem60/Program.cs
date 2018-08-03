using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem60
{
    class Program
    {
        public static List<int> primelist = GeneratePrimesSieveOfEratosthenes(10000000);
        public static HashSet<int> hashprimelist = GeneratePrimesSieveOfEratosthenesHash(10000000);
        public static int[] pair = new int[2];
        static void Main(string[] args)
        {
            Console.WriteLine(PrimePairSets(2000,5));
            Console.ReadLine();
        }
        public static int PrimePairSets(int n, int t)
        {
            int sum = int.MaxValue;
            int[] variablearray = new int[t] ;
            for (int i = 0; i < variablearray.Length; i++)
            {
                variablearray[i] = t - i-1;
            }
            while (variablearray[0]<n)
            {

                int[] testarray = new int[t];
                for (int i = 0; i <testarray.Length; i++)
                {
                    testarray[i] = primelist[variablearray[i]];
                }
                bool foundanswer = test(testarray);

                if (testarray.Sum() < sum&&foundanswer)
                {
                    sum = testarray.Sum();
                }
                
                variablearray[pair.Max()]++;
                bool reset=false;
                for(int i=0;i<variablearray.Length-1;i++)
                {
                    if(variablearray[i]==variablearray[i+1])
                    {
                        variablearray[i]++;
                        reset = true;
                        if(i+1==variablearray.Length-1)
                        {
                            variablearray[variablearray.Length - 1] = 0;
                        }
                        else
                        {
                            variablearray[i + 1] = variablearray[i + 2] + 1;
                        }
                    }
                    if(reset)
                    {
                        variablearray[i + 1] = t-(i+1);
                    }
                }
            }
            return sum;
        }
        public static bool test(int[] array)
        {
            for(int i=0;i<array.Length;i++)
            { 
                for(int j=0;j<array.Length;j++)
                {
                    if(array[i]==array[j])
                    {
                        continue;
                    }
                    int num3 = Concatenate(array[i], array[j]);
                    if(!hashprimelist.Contains(num3))
                    {
                        pair[0] = i;
                        pair[1] = j;
                        return false;
                    }
                }
            }
            return true;
        }
        public static int Concatenate(int n, int k)
        {
            return int.Parse(n.ToString() + k.ToString());
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
        public static HashSet<int> GeneratePrimesSieveOfEratosthenesHash(int n)
        {
            int limit = ApproximateNthPrime(n);
            BitArray bits = SieveOfEratosthenes(limit);
            HashSet<int> primes = new HashSet<int>();
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
