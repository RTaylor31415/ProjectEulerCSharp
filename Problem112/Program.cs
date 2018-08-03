using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem112
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(bouncynumbers(99));
            Console.ReadLine();
        }
        public static int bouncynumbers(int n)
        {
            int bouncy =1;
            int i = 99;
            while((double)bouncy/(double)i<(double)n/100)
            {
                if(isbouncy(i))
                {
                    bouncy++;
                }
                i++;
            }
            return i;
        }
        public static bool isbouncy(int n)
        {
            if(n<100)
            {
                return false;
            }
            bool increasing = false;
            bool decreasing = false;
            int[] newdigits = n.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();
            for(int i=0;i<newdigits.Count()-1;i++)
            {
                if(increasing)
                {
                    if(newdigits[i]>newdigits[i+1])
                    {
                        return true;
                    }
                }
                else if (decreasing)
                {
                    if (newdigits[i] < newdigits[i + 1])
                    {
                        return true;
                    }
                }
                else
                {
                    if (newdigits[i] < newdigits[i + 1])
                    {
                        increasing=true;
                    }
                    if (newdigits[i] > newdigits[i + 1])
                    {
                        decreasing = true;
                    }
                }
            }
            return false;
        }
    }
}
