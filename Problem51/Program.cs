using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem51
{
    class Program
    {
        public static List<int> primes = new List<int>();
        public static HashSet<int> primesHash = new HashSet<int>();
        static void Main(string[] args)
        {
            //Console.WriteLine(GetCombination(test1));
            Stopwatch stopwatch = Stopwatch.StartNew();
            Console.WriteLine(PrimeDigitReplacements(8));
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            Console.ReadLine();
        }
        public static int PrimeDigitReplacements(int n)
        {
            GeneratePrimesSieveOfEratosthenes(1000000);
            int answer = 0;
            int maxprimes = 0;
            int currentprime = 0;
            while(maxprimes<n)
            {
                List<List<int>> combinations = GetCombination(primes[currentprime]);
                int prime = PrimeNumberCombination(combinations, primes[currentprime]);
                if(prime>maxprimes)
                {
                    maxprimes = prime;
                    answer = primes[currentprime];
                }
                currentprime++;
            }
            
            return answer;
            
        }
        public static int PrimeNumberCombination(List<List<int>> combinationlist, int n)
        {
            int max=0;
            foreach(List<int> combination in combinationlist)
            {
                int temp = PrimeCount(combination, n);
                if (temp > max)
                {
                    max = temp;
                }
            }
            return max;
        }
        public static int PrimeCount(List<int> combination, int n)
        {
            int count = 0;
            int[] newdigits = n.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();
            for(int i=0;i<combination.Count-1;i++)
            {
                if(newdigits[combination[i]-1]!=newdigits[combination[i+1]-1])
                {
                    return 0;
                }
            }
            for (int i = 0; i < 10; i++)
            {
                for(int j=0;j<combination.Count;j++)
                {
                    newdigits[combination[j]-1] = i;
                    
                    
                }
                if (newdigits[0] == 0)
                {
                    continue;
                }
                string result = string.Join("", newdigits);
                int prime = int.Parse(result);
                if (primesHash.Contains(prime))
                {
                    count++;
                }
            }
            return count;
        }
        public static List<List<int>> GetCombination(int num)
        {
            string test = num.ToString();
            int length = test.Count();
            List<int> list = new List<int>();
            for(int i=1;i<=length;i++)
            {
                list.Add(i);
            }
            double count = Math.Pow(2, list.Count);
            List<List<int>> result = new List<List<int>>();
            for (int i = 1; i <= count - 1; i++)
            {
                string str = Convert.ToString(i, 2).PadLeft(list.Count, '0');
                List<int> tempresult = new List<int>();
                for (int j = 0; j < str.Length; j++)
                {
                    if (str[j] == '1')
                    {
                        tempresult.Add(list[j]);
                    }
                }
                result.Add(tempresult);
            }
            return result;
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

        public static void GeneratePrimesSieveOfEratosthenes(int n)
        {
            int limit = ApproximateNthPrime(n);
            BitArray bits = SieveOfEratosthenes(limit);
            for (int i = 0, found = 0; i < limit && found < n; i++)
            {
                if (bits[i])
                {
                    primes.Add(i);
                    primesHash.Add(i);
                    found++;
                }
            }
        }
    }
}
