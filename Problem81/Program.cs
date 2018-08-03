using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem81
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PathSumTwoWays(80));
            Console.ReadLine();
        }
        public static int PathSumTwoWays(int n)
        {
            int[,] matrix = new int[n, n];
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\RAT\Documents\Visual Studio 2015\Projects\ProjectEuler\Problem81\bin\p081_matrix.txt");
            string line;
            int count = 0;
            while ((line = file.ReadLine()) != null)
            {
                string[] nums = line.Split(',');
                for(int i=0;i<nums.Length;i++)
                {
                    matrix[count, i] = Int32.Parse(nums[i]);
                }
                count++;
            }
            for(int i=1;i<n;i++)
            {
                matrix[0, i] = matrix[0, i] + matrix[0, i - 1];
                matrix[i, 0] = matrix[i, 0] + matrix[i - 1, 0];
            }
            for(int i=1;i<n;i++)
            {
                for(int j=1;j<n;j++)
                {
                    matrix[i, j] = matrix[i, j] + Math.Min(matrix[i - 1, j], matrix[i, j - 1]);
                }
            }
            return matrix[n-1,n-1];
        }
    }
}
