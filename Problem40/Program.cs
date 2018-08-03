using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Problem40
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Champernowne());
            Console.ReadLine();
        }
        public static int Champernowne()
        {

            ArrayList list = new ArrayList();
            list.Add(0);
            for (int i = 0; i < 1000000; i++)
            {
                int j = i;
                ArrayList templist = new ArrayList();
                while (j > 0)
                {
                    templist.Add(j % 10);
                    j /= 10;
                }
                for(int k= templist.Count-1; k>=0;k--)
                {
                    list.Add(templist[k]);
                }
            }
            return (int)list[1] * (int)list[10] * (int)list[100] * (int)list[1000] * (int)list[10000] * (int)list[100000] * (int)list[1000000];
        }

    }
}
