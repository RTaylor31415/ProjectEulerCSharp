using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


namespace Problem45
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Triangular(10000));
            Console.ReadLine();
        }
        public static int Triangular(int n)
        {
            BigInteger[] triangle = new BigInteger[100000];
            BigInteger[] penta = new BigInteger[100000];
            BigInteger[] hexa = new BigInteger[100000];
            for (int i = 1; i < triangle.Length; i++)
            {
                BigInteger tempi = i;
                triangle[i] = (tempi * (tempi + 1)) / 2;
                penta[i] = (tempi * ((3 * tempi) - 1)) / 2;
                hexa[i] = tempi * ((2 * tempi) - 1);
            }
            var intersect = triangle.Intersect(penta);
            var intersect2 = intersect.Intersect(hexa);
            foreach(BigInteger value in intersect2)
            {
                Console.WriteLine(value);
            }
            return 0;
        }
    }
}
