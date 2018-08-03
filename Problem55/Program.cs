using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Problem55
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LychrelNumbers(10000));
            Console.ReadLine();
        }
        public static int LychrelNumbers(int n)
        {
            int count = 0;
            for(int i=1;i< n;i++)
            {
                if(IsLychrel(i))
                {
                    count++;
                }
            }
            return count;
        }
        public static bool IsPalindrome(BigInteger n)
        {
            string num = n.ToString();
            char[] arr = num.ToCharArray();
            return (new string(arr)== num);
        }
        public static bool IsLychrel(BigInteger n)
        {
            int count = 0;
            bool valid = true;

            for(int i=1;i<50;i++)
            {
                n += ReverseOneLiner(n);
                if (IsPalindrome(n))
                {
                    valid = false;
                    count = i;
                    return valid;
                }
            }
            return valid;
        }
        public static BigInteger ReverseOneLiner(BigInteger num)
        {
            for (BigInteger result = 0; ; result = result * 10 + num % 10, num /= 10) if (num == 0) return result;
        }
    }
}
