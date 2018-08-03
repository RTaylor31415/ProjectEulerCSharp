using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem43
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            Console.WriteLine(SubStringDivisibility());
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            Console.ReadLine();
        }

        private static long SubStringDivisibility()
        {
            long sum = 0;
            int[] primes = new int[] { 2, 3, 5, 7, 11, 13, 17 };
            List<long> substrings = new List<long>();
            List<long> pandigitals = new List<long>();
            long i = 1000000000;
            while (i< 10000000000)
            {
                string numstring = i.ToString();
                bool valid = true;
                for (int j = 0; j < 7; j++)
                {
                    string tempstring = numstring.Substring(j + 1, 3);
                    int divisible = Convert.ToInt32(tempstring);
                    if (divisible % primes[j] != 0)
                    {
                        i += (long)((primes[j] - (divisible % primes[j]))*Math.Pow(10, 6 - j));
                        i-=(long)(i%Math.Pow(10, 6- j));
                        valid = false;
                        break;
                    }
                }
                if(valid)
                {
                    substrings.Add(i);
                  //  Console.WriteLine(i);
                    i++;
                }
            }
            foreach (long j in substrings)
            {
                if(IsPandigital(j))
                {
                    sum += j;
                 //   Console.WriteLine(j);
                }
            }
            return sum;
        }

        public static bool IsPandigital(long i)
        {

            int[] nine = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9,0};
            int[] digits = i.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();
            if (digits.Count() == 10)
            {
                var intersect = nine.Except(digits);
                if (intersect.Count() == 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
