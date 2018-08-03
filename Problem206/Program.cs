using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem206
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ConcealedSquare());
            Console.ReadLine();
        }
        public static long ConcealedSquare()
        {
            for(long i=1000000000L;i< 1415000000L;i+=10)
            {
                if((i* i)%1000>=900)
                {
                    if((i*i)%100000>=80000&&(i*i)%100000<90000)
                    {
                        if ((i * i) % 10000000 >= 7000000 && (i * i) % 10000000 < 8000000)
                        {
                            if ((i * i) % 1000000000L >= 600000000L && (i * i) % 1000000000L < 700000000L)
                            {
                                if ((i * i) % 100000000000L >= 50000000000L && (i * i) % 100000000000L < 60000000000L)
                                {
                                    if ((i * i) % 10000000000000L >= 4000000000000L && (i * i) % 10000000000000L < 5000000000000L)
                                    {
                                        if ((i * i) % 1000000000000000L >= 300000000000000L && (i * i) % 1000000000000000L < 400000000000000L)
                                        {
                                            if ((i * i) % 100000000000000000L >= 20000000000000000L && (i * i) % 100000000000000000L < 30000000000000000L)
                                            {
                                                return i;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return 0;
        }
    }
}
