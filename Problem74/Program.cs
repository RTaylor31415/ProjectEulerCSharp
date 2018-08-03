using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem74
{
    class Program
    {
        public static int[] FactorialList = new int[100];
        static void Main(string[] args)
        {

            Stopwatch stopwatch = Stopwatch.StartNew();
            FactorialList[0] = 1;
            FactorialList[1] = 1;
            Console.WriteLine(DigitFactorialChains(1000000));

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            Console.ReadLine();
        }
        public static int DigitFactorialChains(int n)
        {
            int count = 0;
            for (int i = 1; i < n; i++)
            {
                if(FactorialChains(i)==60)
                {
                    count++;
                }
            }
            return count;
        }
        public static int FactorialChains(int n)
        {
            int count = 0;
            HashSet<int> chain = new HashSet<int>();
            while (!chain.Contains(n))
            {
                chain.Add(n);
                n = DigitFactorial(n);
                count++;
            }
            return count;

        }
        public static int DigitFactorial(int n)
        {
            int sum = 0;
            int[] newdigits = n.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();
            foreach(int digit in newdigits)
            {
                sum += Factorial(digit);
            }
            return sum;
        }
        public static int Factorial(int n)
        {
            if(FactorialList[n]!=0)
            {
                return FactorialList[n];
            }
            else
            {
                int result = n;
                for (int i = 1; i < n; i++)
                {
                    result = result * i;
                }
                FactorialList[n] = result;
                return result;
            }
        }
    }
}
