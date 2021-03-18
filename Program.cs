using System;
using CardGames;

namespace GameOfWar
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            deck.Shuffle();

            foreach (Card card in deck.GetCards())
            {
                Console.WriteLine(card.GetRank() + " of " + card.GetSuit());
            }
        }
    }
}
