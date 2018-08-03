using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Problem56
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PowerfulDigitSum().ToString());
            Console.ReadLine();
        }
        public static BigInteger PowerfulDigitSum()
        {
            int sum = 0;
            for (int i = 1; i <= 100; i++)
            {
                for (int j = 1; j <= 100; j++)
                {
                    BigInteger power = BigInteger.Pow(i, j);
                    int[] newdigits = power.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();
                    int arrsum = newdigits.Sum();
                    if(arrsum>sum)
                    {
                        sum = arrsum;
                    }
                }
            }
            return sum;
        }

    }
}
