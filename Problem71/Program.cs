using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem71
{
    class Program
    {
        static void Main(string[] args)
        {

            Stopwatch stopwatch = Stopwatch.StartNew();
            Console.WriteLine(OrderedFractions(1000000));

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            Console.ReadLine();
        }
        public static int OrderedFractions(int n)
        {
            List < Fractionset > fractions = new List<Fractionset>();
            int count = 1;
            for(int i=1;i<=n;i++)
            {
                for(int j=(int)(2.3*i);((j<=n)&&(j<2.35*i));j++)
                {
                    Fractionset number= new Fractionset(i, j);
                    if(number.eval>0.42857&&number.eval<0.42858)
                    {
                        fractions.Add(number);
                    }
                }
                if(i%10000==0)
                {
                    Console.WriteLine(count);
                    count++;
                }
            }
            List<Fractionset> fractionsorted = fractions.OrderBy(o => o.eval).ToList();
            int index = fractionsorted.FindIndex(a => (a.numerator == 3) && (a.denominator == 7));
            int answer = simplify(fractionsorted[index - 1].numerator, fractionsorted[index - 1].denominator);
            return answer;
        }
        public static int simplify(int n, int k)
        {
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0 && k % i == 0)
                {
                    n /= i;
                    k /= i;
                    i = 2;
                }

            }
            return n;
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
