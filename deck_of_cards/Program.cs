using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Card{
        public string val;
        public string suit;
        public int numerical_value;
        public Card(string val1, string suit1, int num)
        {
            val = val1;
            suit = suit1;
            numerical_value = num;
        }
    
    public class Deck{
        public List<Card> cards = new List<Card>();
        public Deck()
        {
            string[] suits = new string[4]{"Clubs", "Spades", "Hearts", "Diamonds"};
            foreach(string suit in suits)
            {
                for(int i = 1; i < 14; i++)
                {
                    cards.Add(new Card(i, suit));
                }
            }
        }
        public void Shuffle()
        {
            Random rand = new Random();
            for(int i=cards.Count - 1; i>0; i--)
            {
                int index = rand.Next(0, i);
                Card temp = cards[i];
                cards[i] = cards[idx];

            }
        }
        public Card Deal()
        {
            Card temp = cards[0];
            cards.RemoveAt(0);
            return temp;
        }

        public override string ToString()
        {
            foreach(Card card in cards)
            {
                Console.WriteLine
            }
        }
        
    }

    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
