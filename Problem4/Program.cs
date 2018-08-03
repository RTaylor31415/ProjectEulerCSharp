using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LargestPalindromeProduct());
            Console.ReadLine();
        }
        public static int LargestPalindromeProduct()
        {
            int largest = 0;
            for(int i=100;i<1000;i++)
            {
                for(int j=100;j<1000;j++)
                {
                    if (IsPalindrome(i * j)&&((i* j)>largest))
                    {
                        largest = i * j;
                    }
                }
            }
            return largest;
        }
        public static bool IsPalindrome(int n)
        {
            string num = n.ToString();
            char[] arr = num.ToCharArray();
            Array.Reverse(arr);
            return (new string(arr) == num);
        }
    }
}
