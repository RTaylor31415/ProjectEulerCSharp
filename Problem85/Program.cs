using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem85
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CountingRectangles(2000000));
            Console.ReadLine();
        }
        public static int CountingRectangles(int n)
        {
            int answer = int.MaxValue;
            List<int> summations = new List<int>();
            int sum = 0;
            int a=0;
            int b=0;
            for(int i=0;i<1000;i++)
            {
                sum += i;
                summations.Add(sum);
            }
            for(int i=1;i<1000;i++)
            {
                for(int j=1;j<1000;j++)
                {
                    int temp = summations[i] * summations[j];
                    if(Math.Abs(n-temp)<answer)
                    {
                        answer = Math.Abs(n - temp);
                        a = i;
                        b = j;
                    }
                }
            }
            return a*b;
        }
    }
}
