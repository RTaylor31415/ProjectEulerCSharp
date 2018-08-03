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
            Console.WriteLine(PermutedMultiples (10000000));
            //Console.WriteLine(IsPandigital(39, 186));
            Console.ReadLine();
        }
        public static int PermutedMultiples(int n)
        {
            for (int i = 1; i< n;i++)
            {

                bool valid=true;
                int[] digits = i.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();
                for(int j=2;j<6;j++)
                {
                    int[] newdigits = (i* j).ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();
                    if(newdigits.Count()==digits.Count())
                    {
                        var intersect = newdigits.Except(digits);
                        if (intersect.Count() != 0)
                        {
                            valid = false;
                        }
                        
                    }
                    else
                    {
                        valid = false;
                    }
                    
                }
                if (valid)
                    return i;
            }
            return 0;
        }
        public static bool IsPandigital(int[] digits)
        {
           
            int[] nine = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //int[] digits = i.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();
            if (digits.Count()== 9)
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
