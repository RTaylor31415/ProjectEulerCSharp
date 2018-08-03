using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Problem99
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LargestExponential());
            Console.ReadLine();
        }
        public static int LargestExponential()
        {
            
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\RAT\Documents\Visual Studio 2015\Projects\ProjectEuler\Problem99\bin\p099_base_exp.txt");
            string line;
            int count = 1;
            double digitsmax= 0;
            int answer = 0;
            while ((line = file.ReadLine()) != null)
            {
                string[] lines = line.Split(',');
                double digits = Int32.Parse(lines[1]) * Math.Log10(Int32.Parse(lines[0]));
                if (digits > digitsmax)
                {
                    digitsmax = digits;
                    answer = count;
                }
                count++;

            }
            return answer;
        }
    }
}
