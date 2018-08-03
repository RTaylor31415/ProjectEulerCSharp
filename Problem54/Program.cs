using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem54
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Pokerhands());
            Console.ReadLine();
        }
        public static int Pokerhands()
        {
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\RAT\Documents\Visual Studio 2015\Projects\ProjectEuler\Problem54\bin\p054_poker.txt");
            string line;
            int count = 0;
            while ((line = file.ReadLine()) != null)
            {
                string[] cards = line.Split(' ');
                string[] playerone = cards.Take(cards.Length / 2).ToArray();
                string[] playertwo = cards.Skip(cards.Length / 2).ToArray();
                List<int> playeronehand = handstrength(playerone);
                List<int> playertwohand = handstrength(playertwo);
                if (CompareHands(playeronehand,playertwohand))
                {
                    count++;
                }
            }
            return count;
        }
        public static bool CompareHands(List<int> one, List<int> two)
        {
            for(int i=0;i<one.Count;i++)
            {
                if(one[i]>two[i])
                {
                    return true;
                }
                else if(one[i]<two[i])
                {
                    return false;
                }
            }
            return true;
        }
        public static List<int> handstrength(string[] pokerhand)
        {
            bool flush = true;
            bool straight = true;
            char firstsuit = pokerhand[0][1];
            int[] cardnums = new int[5];
            int pair=0;
            int pair2=0;
            int trips=0;
            int quads=0;
            int kicker1 = 0;
            int kicker2 = 0;
            int kicker3 = 0;
            bool ace = false;
            for (int i=0;i<pokerhand.Length;i++)
            {
                cardnums[i] = ConvertCardToInt(pokerhand[i][0]);
                if(pokerhand[i][1]!=firstsuit)
                {
                    flush = false;
                }
            }
            Array.Sort(cardnums);
            if(cardnums[4]==14)
            {
                ace = true;
            }
            for(int i=0;i<cardnums.Length-1;i++)
            {
                if (cardnums[i] != cardnums[i + 1] - 1 ^ (i == 0&&cardnums[0]==14&&cardnums[1]==2))
                {
                    straight = false;
                }
            }

            Array.Reverse(cardnums);
            var outval = from ii in cardnums
                         group ii by ii into iiGroup
                         select new { iiGroup, iiCount = iiGroup.Count() };
            foreach(var item in outval)
            {
                if (item.iiCount == 2 && pair != 0)
                {
                    pair2 = item.iiGroup.Key;
                }
                if (item.iiCount==2)
                {
                    pair = item.iiGroup.Key;
                }
                if (item.iiCount==3)
                {
                    trips = item.iiGroup.Key;
                }
                if(item.iiCount==4)
                {
                    quads = item.iiGroup.Key;
                }
                if (item.iiCount == 1 && kicker2 != 0)
                {
                    kicker3 = item.iiGroup.Key;
                }
                if (item.iiCount == 1 && kicker1 != 0&&kicker3==0)
                {
                    kicker2 = item.iiGroup.Key;
                }
                if (item.iiCount == 1&&kicker2==0&&kicker3==0)
                {
                    kicker1 = item.iiGroup.Key;
                }
            }
            List<int> hand = new List<int>();
            if(straight&&flush)
            {
                hand.Add(10);
                hand = hand.Concat(cardnums).ToList();
            }
            else if(quads!=0)
            {
                hand.Add(9);
                hand.Add(quads);
                hand.Add(quads);
                hand.Add(quads);
                hand.Add(quads);
                hand.Add(kicker1);
            }
            else if(trips!=0&&pair!=0)
            {
                hand.Add(8);
                hand.Add(trips);
                hand.Add(trips);
                hand.Add(trips);
                hand.Add(pair);
                hand.Add(pair);
            }
            else if (flush)
            {
                hand.Add(7);
                hand = hand.Concat(cardnums).ToList();
            }
            else if (straight)
            {
                if(ace==true)
                {
                    hand.Add(6);
                    hand = hand.Concat(cardnums).ToList();
                    if (hand.Contains(5))
                    {
                        hand.RemoveAt(1);
                        hand.Add(14);
                    }

                }
                else
                {
                    hand.Add(6);
                    hand = hand.Concat(cardnums).ToList();
                }
            }
            else if(trips!=0)
            {
                hand.Add(5);
                hand.Add(trips);
                hand.Add(trips);
                hand.Add(trips);
                hand.Add(kicker1);
                hand.Add(kicker2);
            }
            else if(pair2!=0)
            {
                hand.Add(4);
                hand.Add(pair);
                hand.Add(pair);
                hand.Add(pair2);
                hand.Add(pair2);
                hand.Add(kicker1);
            }
            else if(pair!=0)
            {
                hand.Add(3);
                hand.Add(pair);
                hand.Add(pair);
                hand.Add(kicker1);
                hand.Add(kicker2);
                hand.Add(kicker3);
            }
            else
            {
                hand.Add(2);
                hand = hand.Concat(cardnums).ToList();
            }

            return hand;
        }
        public static int ConvertCardToInt(char c)
        {
            if(c=='T')
            {
                return 10;
            }
            else if(c=='J')
            {
                return 11;
            }
            else if(c=='Q')
            {
                return 12;
            }
            else if(c=='K')
            {
                return 13;
            }
            else if(c=='A')
            {
                return 14;
            }
            else
            {
                return int.Parse(c.ToString()); ;
            }
        }
        public static void SwapInts(int[] array, int position1, int position2)
        {
            int temp = array[position1]; // Copy the first position's element
            array[position1] = array[position2]; // Assign to the second element
            array[position2] = temp; // Assign to the first element
        }
    }
}
