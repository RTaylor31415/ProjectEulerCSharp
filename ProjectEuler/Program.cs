using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class Program
    {
        public static List<uint> PlayerIDList;
        static void Main(string[] args)
        {
            uint pie = 4;
            PlayerIDList = new List<uint>();
            PlayerIDList.Add(pie);
            pie = 3;
            Console.WriteLine(PlayerIDList[0]);
            Console.ReadLine();
        }
        static void SquareIt(ref int x)
        // The parameter x is passed by reference.
        // Changes to x will affect the original value of x.
        {
            x *= x;
            System.Console.WriteLine("The value inside the method: {0}", x);
        }


    }
}
