using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Problem44
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PentagonNumbers());
            Console.ReadLine();
        }
        public static int PentagonNumbers()
        {
            int D = int.MaxValue;
            int[] penta = new int[3000];
            List<int> pentaboth = new List<int>();
            for (int i = 1; i <= penta.Length; i++)
            {
                penta[i-1] = (i * ((3 * i) - 1)) / 2;
            }
            for(int i=1;i<penta.Length;i++)
            {
                for(int j=i;j<penta.Length;j++)
                {
                    int temp = penta[i];
                    int temp2 = penta[j];
                    if(penta.Contains(Math.Abs((temp-temp2)))&&penta.Contains(temp+temp2))
                    {
                        if(Math.Abs(temp2-temp)<D)
                        {
                            D = Math.Abs(temp2 - temp);
                            Console.WriteLine("{0} {1} {2}", i, j, D);
                        }
                    }
                }
            }

            return D;
        }

    }
}
