using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem79
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PasscodeDerivation());
            Console.ReadLine();
        }
        public static string PasscodeDerivation()
        {
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\RAT\Documents\Visual Studio 2015\Projects\ProjectEuler\Problem79\bin\p079_keylog.txt");
            int counter = 0;
            string line;
            List<char> passcode = new List<char>();
            while ((line = file.ReadLine()) != null)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (!passcode.Contains(line[i]))
                    {
                        passcode.Add(line[i]);
                    }
                }
                for (int i = 0; i < line.Length; i++)
                {
                    for (int j=i;j<line.Length;j++)
                    {
                        if (passcode.IndexOf(line[i]) > passcode.IndexOf(line[j]))
                        {
                            Swap(passcode, passcode.IndexOf(line[i]), passcode.IndexOf(line[j]));
                        }
                    }
                    
                }
                counter++;
            }
            char[] finalstring = passcode.ToArray();
            return new string(finalstring);
        }
        public static void Swap<T>(IList<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }
    }
}
