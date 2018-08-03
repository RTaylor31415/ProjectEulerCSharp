using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(multiples(3, 5, 1000));
            Console.ReadLine();

        }
        public static int multiples(int n,int k, int m)
        {
            int sum = 0;
            for(int i=0;i< m;i++)
            {
                if(i%n==0||i%k==0)
                {
                    sum += i;
                }
            }
            return sum;
        }
    }
}
