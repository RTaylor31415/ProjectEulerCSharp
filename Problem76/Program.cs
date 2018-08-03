using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem76
{
    class Program
    {
        public static int[] aiPn = new int[1000]; 
        static void Main(string[] args)
        {
            aiPn[0] = 1;
            Stopwatch stopwatch = Stopwatch.StartNew();
            //Console.WriteLine(CountingSummations(20));
            // Console.WriteLine(RecursiveFunction(5, 0));
            Console.WriteLine(CalcPn(5)-1);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            Console.ReadLine();
        }
        public static int CountingSummations(int n)
        {
            List<List<int>> result = possiblesummations(n);
            return result.Count - 1;
        }
        public static int CalcPn(long n)
        {
            // P(<0) = 0 by convention
            if (n < 0)
                return 0;

            // Use cached value if already calculated
            if (aiPn[n] > 0)
                return aiPn[n];

            int Pn = 0;
            for (long k = 1; k <= n; k++)
            {
                // A little bit of recursion
                long n1 = n - k * (3 * k - 1) / 2;
                long n2 = n - k * (3 * k + 1) / 2;

                int Pn1 = CalcPn(n1);
                int Pn2 = CalcPn(n2);

                // elements are alternately added and subtracted
                if (k % 2 == 1)
                    Pn = Pn + Pn1 + Pn2;
                else
                    Pn = Pn - Pn1 - Pn2;

            }

            // Cache calculated valued
            aiPn[n] = Pn;
            return Pn;
        }

        public static List<List<int>> possiblesummations(int n)
        {
            List<List<int>> final = new List<List<int>>();
            List<int> currentlist = new List<int>();
            currentpossibility(n,currentlist, final);

            return final;
        }
        public static void currentpossibility(int n,List<int> currentlist, List<List<int>> results)
        {
            if(n==0)
            {
                List<int> y = new List<int>(currentlist);
                y.Sort();
                bool valid = true;
                foreach(List<int> blah in results)
                {
                    if (blah.SequenceEqual(y))
                    {
                        valid = false;
                        break;
                    }
                }
                if (valid)
                {
                    results.Add(y);
                }
            }
            else
            {
                for(int i=1;i<= n;i++)
                {
                    currentlist.Add(i);
                    currentpossibility(n-i, currentlist, results);
                    currentlist.Remove(i);
                }
            }
        }
    }
}
