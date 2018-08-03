using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem31
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CoinSums(200));
            Console.ReadLine();
        }
        public static int CoinSums(int sum)
        {
            int count = 0;
            int[] coins = new int[8] { 1, 2, 5, 10, 20, 50, 100, 200 };
            for (int a = sum; a >= 0; a -= 200)
            {
                for (int b = a; b >= 0; b -= 100)
                {
                    for (int c = b; c >= 0; c -= 50)
                    {
                        for (int d = c; d >= 0; d -= 20)
                        {
                            for (int e = d; e >= 0; e -= 10)
                            {
                                for (int f = e; f >= 0; f -= 5)
                                {
                                    for (int g = f; g >= 0; g -= 2)
                                    {
                                            count++;
                                     
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return count;
        }

    }
}
