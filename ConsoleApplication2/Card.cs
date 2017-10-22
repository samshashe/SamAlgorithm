using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main1(string[] args)
        {
            //Create a new Deck with 52 cards and write out its values. 
            Deck deck = new Deck(52);
            Console.WriteLine("Before shuffle");
            foreach (Card card in deck.Cards)
            {
                Console.WriteLine(card.number);
            }

            //shuffle deck and write out its values. 
            deck.Shuffle();
            Console.WriteLine();
            Console.WriteLine("After shuffle");
            foreach (Card card in deck.Cards)
            {
                Console.WriteLine(card.number);
            }

            Console.WriteLine("Press ENTER to quit");
            Console.ReadLine();
        }
    } 
    public class Card
    {
        public Card(int number) { this.number = number; }
        public int number; 
    }
    public class Deck
    {
        public Card[] Cards;
        public Deck(int totalCards)
        {
            this.Cards = new Card[totalCards];
            for (int i = 1; i <= totalCards; i++)
            {
                this.Cards[i - 1] = new Card(i);
            }
        }

        public void Shuffle()
        {
            Card[] tempDeck = this.Cards;
            this.Cards = new Card[tempDeck.Length];
            List<int> availableIndices = new List<int>(tempDeck.Length);
            Random rand = new Random();

            for (int i = 0; i < tempDeck.Length; i++)
                availableIndices.Add(i);

            foreach (Card card in tempDeck)
            {
                int rndAvailableIndex = rand.Next(availableIndices.Count);
                int newCardIndex = availableIndices[rndAvailableIndex];

                this.Cards[newCardIndex] = card;
                availableIndices.Remove(newCardIndex);

            }
        }
    }  
}
