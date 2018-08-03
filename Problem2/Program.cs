using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Fibbonacci(4000000));
            Console.ReadLine();
        }
        public static int Fibbonacci(int n)
        {
            int sum=0;
            int j = 1;
            int k = 1;
            while(k<4000000)
            {
                if(k%2==0)
                {
                    sum += k;
                }
                int temp = k;
                k = j + temp;
                j = temp;
            }
            return sum;
        }
    }
}
