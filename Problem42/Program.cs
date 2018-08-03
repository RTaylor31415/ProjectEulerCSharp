using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem42
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\RAT\Downloads\p042_words.txt");
            
            
            string[] testcase = lines[0].Split(',');

            for(int i=0;i<testcase.Length;i++)
            {
                testcase[i] = testcase[i].Replace("\"", string.Empty);
            }
            int[] triangle = new int[100];
            for(int i=0;i<triangle.Length;i++)
            {
                triangle[i] = (i * (i + 1)) / 2;
            }
            int count = 0;
            foreach(string word in testcase)
            {
                int sum = 0;
                foreach(char letter in word)
                {
                    sum += (Convert.ToInt32(letter) - 64);
                }
                if (triangle.Contains(sum))
                {
                    count++;
                }
            }
            Console.WriteLine(count);
            Console.ReadLine();
                
                
        }
    }
}
