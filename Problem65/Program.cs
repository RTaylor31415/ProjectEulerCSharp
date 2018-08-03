using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Problem65
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(eConvergents(100));
            Console.ReadLine();
        }
        public static BigInteger eConvergents(int n)
        {
            BigInteger previousk = 8;
            BigInteger k = 11;
            BigInteger previousj = 3;
            BigInteger j = 4;
            int m = 4;
            BigInteger sum=0;
            for (int i = 2; i < n-2; i++)
            {
                if(i%3==0)
                {
                    BigInteger temp1 = k;
                    BigInteger temp2 = j;
                    k = k * m + previousk;
                    j = j * m + previousj;
                    previousk = temp1;
                    previousj = temp2;
                    
                    m+=2;
                }
                else
                {
                    BigInteger temp1 = k;
                    BigInteger temp2 = j;
                    k = k + previousk;
                    j = j + previousj;
                    previousk = temp1;
                    previousj = temp2;
                }
            }
            while(k>0)
            {
                sum += (k % 10);
                k /= 10;
            }
            return sum;
        }
        public static int simplify(int n, int k)
        {
            for(int i=2;i< n;i++)
            {
                if(n%i==0&&k%i==0)
                {
                    n /= i;
                    k /= i;
                }

            }
            return n;
        }
    }
}
