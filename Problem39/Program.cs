using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem39
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Triangles(10000));
            Console.ReadLine();
        }
        public static int Triangles(int n)
        {
            int max = 0;
            int placeholder = 0;
            for(int i=4;i< n;i++)
            {
                if(counttriangles(i) >max)
                {
                    max = counttriangles(i);
                    placeholder = i;
                    Console.WriteLine(i);
                    Console.WriteLine(max);
                }
            }
            return placeholder;
        }
        public static int counttriangles(int n)
        {
            int count = 0;
            ArrayList list = new ArrayList();
            for(int i=1;i< n;i++)
            {
                for (int j = 1; j < (n - i);j++)
                {
                    int k = (n - i) - j;
                    if (IsRightTriangle(i, j, k))
                    {
                        int[] temparray = new int[3] { i, j, k };
                        Array.Sort(temparray);
                        bool valid = true;
                        for(int m=0;m<list.Count;m++)
                        {
                            if (temparray.SequenceEqual((int[])list[m]))
                            {
                                valid = false;
                            }
                        }
                        if(valid)
                        { 
                        
                        list.Add(temparray);
                        //Console.WriteLine("{0},{1},{2}", i, j, k);
                        count++;
                        }
                    }
                    
                }
            }
            return count;
        }
        public static bool IsRightTriangle(int a,int b,int c)
        {
            int[] triangle = new int[3] { a, b, c };
            Array.Sort(triangle);
            return (((a * a) + (b * b)) == (c * c));
        }
        
    }
}
