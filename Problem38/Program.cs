using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem52
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PandigitalMultiples(100000));
            //Console.WriteLine(IsPandigital(39, 186));
            Console.ReadLine();
        }
        public static int PandigitalMultiples(int n)
        {
            int largest = 0;
            for (int i = 1; i < n; i++)
            {
                int[] digits = i.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();
                List<int> finaldigits = new List<int>();
                finaldigits.AddRange(digits);
                for (int j = 2; j < 6; j++)
                {
                    int[] newdigits = (i * j).ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();
                    finaldigits.AddRange(newdigits);
                    if (finaldigits.Count() == 9)
                    {
                        int[] finalarray = finaldigits.ToArray();
                        if (IsPandigital(finalarray))
                        {
                            int temp2 = 0;
                            for (int k = 0; k < finalarray.Count(); k++)
                            {
                                temp2 += (int)finalarray[k] * (int)Math.Pow(10, finalarray.Count() - k - 1);
                            }
                            if (temp2 > largest)
                            {
                                largest = temp2;
                            }
                        }

                    }
                }
            }
            return largest;
        }
        public static bool IsPandigital(int[] digits)
        {

            int[] nine = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //int[] digits = i.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();
            if (digits.Count() == 9)
            {
                var intersect = nine.Except(digits);
                if (intersect.Count() == 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
