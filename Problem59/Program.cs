using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem59
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(XORDecryption());
            Console.ReadLine();
        }
        public static string XORDecryption()
        {

            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\RAT\Documents\Visual Studio 2015\Projects\ProjectEuler\Problem59\bin\p059_cipher.txt");
            string test = file.ReadLine();
            string[] numbers = test.Split(',');
            List<string> cipher1 = new List<string>();
            List<string> cipher2 = new List<string>();
            List<string> cipher3 = new List<string>();
            for (int i=0;i<numbers.Length;i++)
            {
                if (i % 3 == 0)
                {
                    cipher1.Add(numbers[i]);
                }
                if (i % 3 == 1)
                {
                    cipher2.Add(numbers[i]);
                }
                if (i % 3 == 2)
                {
                    cipher3.Add(numbers[i]);
                }
            }
            List<char> cipher1solved = decodeciper(cipher1);
            List<char> cipher2solved = decodeciper(cipher2);
            List<char> cipher3solved = decodeciper(cipher3);
            List<char> unscrambled = new List<char>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (i % 3 == 0)
                {
                    unscrambled.Add(cipher1solved[i / 3]);
                }
                if (i % 3 == 1)
                {
                    unscrambled.Add(cipher2solved[i / 3]);
                }
                if (i % 3 == 2)
                {
                    unscrambled.Add(cipher3solved[i / 3]);
                }
            }
            int sum = 0;
            foreach(char letter in unscrambled)
            {
                sum += (int)letter;
            }
            Console.WriteLine(sum);
            return new string(unscrambled.ToArray());
        }
        public static int[] findcipher(List<string> cipherkey)
        {

            int[] spacearray = new int[] { 0, 0, 1, 0, 0, 0, 0, 0 };
            Dictionary<string, int> ciphercount1 = CountItems(cipherkey);
            ciphercount1 = ciphercount1.OrderByDescending(i => i.Value).ToDictionary(i => i.Key, i => i.Value);
            int firstnum = Convert.ToInt32(ciphercount1.Keys.First());
            string s = Convert.ToString(firstnum, 2); //Convert to binary in a string

            int[] bits = s.PadLeft(8, '0') // Add 0's from left
                         .Select(c => int.Parse(c.ToString())) // convert each char to int
                         .ToArray(); // Convert IEnumerable from select to Array

            return XOR(bits, spacearray);

        }
        public static List<char> decodeciper(List<string> cipherkey)
        {
            List<int> cipherint = cipherkey.Select(int.Parse).ToList();

            List<int[]> cipherbyte = new List<int[]>();
            for (int i = 0; i < cipherint.Count; i++)
            {
                string s = Convert.ToString(cipherint[i], 2); //Convert to binary in a string

                int[] bits = s.PadLeft(8, '0') // Add 0's from left
                             .Select(c => int.Parse(c.ToString())) // convert each char to int
                             .ToArray(); // Convert IEnumerable from select to Array
                cipherbyte.Add(bits);
            }
            int[] decoder = findcipher(cipherkey);
            List<int[]> decodedcipher = new List<int[]>();
            List<char> decodedcipherchar = new List<char>();
            for (int i = 0; i < cipherbyte.Count; i++)
            {
                decodedcipher.Add(XOR(cipherbyte[i], decoder));
            }
            for (int i = 0; i < decodedcipher.Count; i++)
            {
                int sum = 0;
                for (int j = 0; j < decodedcipher[i].Count(); j++)
                {
                    sum *= 2;
                    sum += decodedcipher[i][j];
                }
                decodedcipherchar.Add(Convert.ToChar(sum));
            }
            return decodedcipherchar;
        }
        public static Dictionary<string, int> CountItems(List<string> stuff)
        {
            var groups = from s in stuff group s by s into g select new { Stuff = g.Key, Count = g.Count() };
            var dictionary = groups.ToDictionary(g => g.Stuff, g => g.Count);
            return dictionary;
        }
        public static Dictionary<char, int> CountItems(List<char> stuff)
        {
            var groups = from s in stuff group s by s into g select new { Stuff = g.Key, Count = g.Count() };
            var dictionary = groups.ToDictionary(g => g.Stuff, g => g.Count);
            return dictionary;
        }
        public static int[] XOR(int[] a, int[]b)
        {
            int[] result = new int[8];
            for (int i = 0; i < 8; i++)
            {
                if(a[i]==0&&b[i]==0)
                {
                    result[i] = 0;
                }

                if (a[i] == 1 && b[i] == 0)
                {
                    result[i] = 1;
                }
                if (a[i] == 0 && b[i] == 1)
                {
                    result[i] = 1;
                }
                if (a[i] == 1 && b[i] == 1)
                {
                    result[i] = 0;
                }
            }

            return result;
        }
    }
}
