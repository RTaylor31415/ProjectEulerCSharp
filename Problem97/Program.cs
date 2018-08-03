using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Problem97
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LargeMersenne());
            Console.ReadLine();
        }
        public static string LargeMersenne()
        {
            BigInteger mersenne = (28433*BigInteger.Pow(2, 7830457))+1;
            BigInteger result = mersenne % 10000000000;
            return result.ToString();
        }
    }
}
