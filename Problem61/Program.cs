using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Problem61
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CyclicalFigurate(10000));
            Console.ReadLine();
        }
        public static int CyclicalFigurate(int num)
        {
            List<int> triangle = new List<int>();
            List<int> square = new List<int>();
            List<int> penta = new List<int>();
            List<int> hexa = new List<int>();
            List<int> hepta = new List<int>();
            List<int> octa = new List<int>();
            for (int i = 1; i < 1000; i++)
            {
                int triangletemp = (i * (i + 1)) / 2;
                int squaretemp = i * i;
                int pentatemp = (i * ((3 * i) - 1)) / 2;
                int hexatemp = i * ((2 * i) - 1);
                int heptatemp = (i * ((5 * i) - 3)) / 2;
                int octatemp = i * ((3 * i) - 2);
                if (triangletemp >= 1000 && triangletemp < 10000)
                {
                    triangle.Add(triangletemp);
                }
                if (squaretemp >= 1000 && squaretemp < 10000)
                {
                    square.Add(squaretemp);
                }
                if (pentatemp >= 1000 && pentatemp < 10000)
                {
                    penta.Add(pentatemp);
                }
                if (hexatemp >= 1000 && hexatemp < 10000)
                {
                    hexa.Add(hexatemp);
                }
                if (heptatemp >= 1000 && heptatemp < 10000)
                {
                    hepta.Add(heptatemp);
                }
                if (octatemp >= 1000 && octatemp < 10000)
                {
                    octa.Add(octatemp);
                }
            }
            List<List<int>> listoflists = new List<List<int>>();
            listoflists.Add(triangle);
            listoflists.Add(square);
            listoflists.Add(penta);
            listoflists.Add(hexa);
            listoflists.Add(hepta);
            listoflists.Add(octa);
            List<List<List<int>>> cyclicnumbers = new List < List<List<int>>>();

            List<List<List<int>>> cyclicnumbers2 = new List<List<List<int>>>();
            List<int> checkedlists = new List<int>();
            List<int> answer = new List<int>();
            List<List<int>> cyclictest = new List<List<int>>();
            List<List<int>> cyclictesttest = new List<List<int>>();
            List<List<int>> cyclictesttest2 = new List<List<int>>();
            List<List<int>> cyclictesttest3 = new List<List<int>>();
            List<List<int>> cyclictesttest4 = new List<List<int>>();
            

            for (int k = 0; k < listoflists.Count; k++)
            {
                for (int i = 0; i < listoflists.Count; i++)
                {
                    if(i==k)
                    {
                        continue;
                    }

                    for(int j=0;j<listoflists[k].Count;j++)
                    {
                        for(int l=0;l<listoflists[i].Count;l++)
                        {
                            if (Cyclic(listoflists[k][j], listoflists[i][l]))
                            {
                                List<int> cyclictest2 = new List<int>();

                                cyclictest2.Add(k);
                                cyclictest2.Add(listoflists[k][j]);

                                cyclictest2.Add(i);
                                cyclictest2.Add(listoflists[i][l]);

                                cyclictest.Add(cyclictest2);
                            }
                        }
                    }
                }
            }
            cyclictesttest = findnextnumber(cyclictest, cyclictest);
            cyclictesttest2 = findnextnumber(cyclictest, cyclictesttest);
            cyclictesttest3 = findnextnumber(cyclictest, cyclictesttest2);
            cyclictesttest4 = findnextnumber(cyclictest, cyclictesttest3);
            
            for (int i = 0; i < cyclictesttest4.Count; i++)
            {
                if(Cyclic(cyclictesttest4[i][11],cyclictesttest4[i][1]))
                {
                    answer = cyclictesttest4[i];
                }
            }
            int sum = 0;
            for(int i=1;i<answer.Count;i+=2)
            {
                sum += answer[i];
            }
            return sum;
        }
        public static List<List<int>> findnextnumber(List<List<int>> cyclictest, List<List<int>> cyclictesttest)
        {

            List<List<int>> cyclictesttest2 = new List<List<int>>();
            for (int i = 0; i < cyclictesttest.Count; i++)
            {

                for (int j = 0; j < cyclictest.Count; j++)
                {

                    List<int> cyclic3 = new List<int>(cyclictesttest[i]);
                    if (cyclictest[j][0] == cyclic3[cyclic3.Count - 2] && cyclictest[j][1] == cyclic3[cyclic3.Count - 1] && !cyclic3.Contains(cyclictest[j][2]))
                    {
                        cyclic3.Add(cyclictest[j][2]);
                        cyclic3.Add(cyclictest[j][3]);

                        cyclictesttest2.Add(cyclic3);
                    }

                }
            }
            return cyclictesttest2;
        }

        public static bool Cyclic(int a, int b)
        {
            if(a==b)
            {
                return false;
            }
            return (a % 100 == b / 100);
        }
    }
}
