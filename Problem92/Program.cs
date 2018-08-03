using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem92
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            Console.WriteLine(SquareDigitChains(10000000));
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            Console.ReadLine();
        }
        public static int SquareDigitChains(int n)
        {
            int count = 0;
            for (int i = 1; i < n; i++)
            {
                if(DigitChain89(i))
                {
                    count++;
                }
            }
            return count;
        }
        public static bool DigitChain89(int n)
        {
            while(n!=1)
            {
                if(n==89)
                {
                    return true;
                }
                else
                {
                    n = SquareDigits(n);
                }
            }
            return false;
        }
        public static int SquareDigits(int n)
        {
            int sum=0;
            int[] newdigits = n.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();
            for(int i=0;i<newdigits.Length;i++)
            {
                sum += newdigits[i] * newdigits[i];
            }
            return sum;
        }
    }
}
