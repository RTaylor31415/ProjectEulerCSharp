using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LargestPrimeFactor(600851475143D));
            Console.ReadLine();
        }
        public static double LargestPrimeFactor(double n)
        {
            for(double i=2;i<n/2;i++)
            {
                if (n % i==0)
                {
                    n /= i;
                    i = 2;
                }
            }
            return n;
        }
    }
}
