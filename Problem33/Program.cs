using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem33
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DigitCancel(100));
            Console.ReadLine();
        }
        public static int DigitCancel(int max)
        {
            int topnumber = 1;
            int bottomnumber = 1;
            for(int i=11;i< max;i++)
            {
                for(int j=11;j< i;j++)
                {
                    double frac = (double)j / (double)i;
                    int[] first = new int[] { (i / 10), i % 10 };
                    int[] second = new int[] { (j / 10), j % 10 };
                    if(i%10==0||j%10==0)
                    {
                        continue;
                    }
                    if(first[0]==second[0])
                    {
                        if(((double)second[1]/ (double)first[1])==frac)
                        {
                            Console.WriteLine("{0}, {1}", j, i);
                            topnumber *= j;
                            bottomnumber *= i;
                        }
                    }
                    if (first[0] == second[1])
                    {
                        if (((double)second[0] / (double)first[1]) == frac)
                        {
                            Console.WriteLine("{0}, {1}", j, i);
                            topnumber *= j;
                            bottomnumber *= i;
                        }
                    }
                    if (first[1] == second[0])
                    {
                        if (((double)second[1] / (double)first[0]) == frac)
                        {
                            Console.WriteLine("{0}, {1}", j, i);
                            topnumber *= j;
                            bottomnumber *= i;
                        }
                    }
                    if (first[1] == second[1])
                    {
                        if (((double)second[0] / (double)first[0]) == frac)
                        {
                            Console.WriteLine("{0}, {1}", j, i);
                            topnumber *= j;
                            bottomnumber *= i;
                        }
                    }
                }
            }
            Console.WriteLine(topnumber);
            Console.WriteLine(bottomnumber);

            return 0;
        }
    }
}
