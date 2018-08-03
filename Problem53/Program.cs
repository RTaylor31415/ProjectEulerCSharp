using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Problem53
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(choose(23, 10));
            Console.WriteLine(CombinatoricSelections());
            Console.ReadLine();
        }
        public static int CombinatoricSelections()
        {
            int count=0;
            for(int i=1;i<=100;i++)
            {
                for(int j=1;j<= i;j++)
                {
                    if (choose(i, j) > 1000000)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        public static BigInteger choose (int i, int j)
        {
            return (factorial(i) / (factorial(j) * factorial(i - j)));
        }
        public static BigInteger factorial(int i)
        {
            BigInteger j = 1;
            while(i>0)
            {
                j *= i;
                i--;
            }
            return j;
        }
    }
}
