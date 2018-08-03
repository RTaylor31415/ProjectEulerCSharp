using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Problem57
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SquareRootConvergents(1000));
            Console.ReadLine();
        }
        public static int SquareRootConvergents(int n)
        {
            int count = 0;
            BigInteger previousk = 1;
            BigInteger k = 3;
            BigInteger previousj = 1;
            BigInteger j = 2;
            for(int i=0;i<=1000;i++)
            {
                BigInteger temp1 = k;
                BigInteger temp2 = j;
                k = k * 2 + previousk;
                j = j * 2 + previousj;
                previousk = temp1;
                previousj = temp2;
                if(k.ToString().Length>j.ToString().Length)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
