using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem32
{
    class Program
    {
        static void Main(string[] args)
        {
             Console.WriteLine(Pandigital());
            //Console.WriteLine(IsPandigital(39, 186));
            Console.ReadLine();
        }
        public static int Pandigital()
        {
            int sum=0;
            ArrayList products = new ArrayList();
            for (int i = 1; i < 10000; i++)
            {
                for(int j=i;j<10000;j++)
                {
                   if(IsPandigital(i,j))
                    {
                        if (!products.Contains(i * j))
                        {
                            sum += (i * j);
                            products.Add(i * j);
                        }
                    }
                }
            }
            return sum;
        }
        public static bool IsPandigital(int i,int j)
        {
            int k = i * j;
            int[] nine = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] digits = i.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();
            int[] digits2 = j.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();
            int[] digits3 = k.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();
            if (digits.Count() + digits2.Count() + digits3.Count() == 9)
            {

                var intersect = nine.Except(digits);
                var intersect2 = intersect.Except(digits2);
                var intersect3 = intersect2.Except(digits3);
                if (intersect3.Count() == 0)
                {
                    Console.WriteLine("{0},{1},{2}", i, j, k);
                    return true;
                }
            }
            return false;
        }
    }
}
