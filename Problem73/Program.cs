using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem73
{
    class Program
    {
        static void Main(string[] args)
        {

            Stopwatch stopwatch = Stopwatch.StartNew();
            Console.WriteLine(CountingOrderedFractions(12000));

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            Console.ReadLine();
        }
        public static int CountingOrderedFractions(int n)
        {
            List<Fractionset> fractions = new List<Fractionset>();
            for (int i = 1; i <= n; i++)
            {
                for (int j = 2*i; (j <= 3*i)&&(j<= n) ; j++)
                {
                    
                    Fractionset number = new Fractionset(i, j);
                    fractions.Add(number);
                }
                if(i%120==0)
                {
                    Console.WriteLine(i / 120);
                }
            }
            List<Fractionset> fractionsorted = fractions.OrderBy(o => o.eval).ToList();
            bool duplicate = true; 
            int count = -2;
            double lastdouble = 0;
            double margin = 0.000000001;
            for(int i=1;i<fractionsorted.Count;i++)
            {
                if(duplicate==false)
                {
                    count++;
                    //Console.WriteLine(lastdouble);
                }
                if (Math.Abs(fractionsorted[i].eval - lastdouble) <= margin)
                {
                    duplicate = true;
                }
                else
                {
                    duplicate = false;
                }
                lastdouble = fractionsorted[i].eval;
            }
            
            return count;
        }


    }
    class Fractionset
    {
        public double eval;
        public int numerator;
        public int denominator;
        public Fractionset(int numerator, int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
            eval = (double)numerator / (double)denominator;
        }
    }
}
