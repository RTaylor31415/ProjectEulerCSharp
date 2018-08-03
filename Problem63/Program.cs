using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Problem63
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(powerchecker(17));
            Console.WriteLine(powerchecker(16807));
            Console.WriteLine(powerfuldigitcounts());
            Console.ReadLine();
        }
        public static int powerfuldigitcounts()
        {
            int count=0;
            int percentage = 1;
            List<BigInteger> uniquenumbers = new List<BigInteger>();
            for(int i=0;i<40;i++)
            {
                for (int j = 1;j < 3000;j++)
                {
                    if (powerchecker(BigInteger.Pow(i, j)) && !uniquenumbers.Contains(BigInteger.Pow(i, j)))
                    {
                        uniquenumbers.Add(BigInteger.Pow(i, j));
                        count++;
                    }
                }
                if(i%2==0)
                {
                    Console.WriteLine(percentage);
                    percentage++;
                }
            }
            return count+1;
        }
        public static bool powerchecker(BigInteger num)
        {
            string numstring = num.ToString();
            int digits = numstring.Length;
            BigInteger test = 1;
            int count = 1;
            while (test<num)
            {
                test = BigInteger.Pow(count, digits);
                if(test==num)
                {
                    return true;
                }
                count++;
            }
            return false;
        }
    }
}
