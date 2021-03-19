using System;
using CardGames;

namespace GameOfWar
{
    class PlayGameOfWar
    {
        static void Main(string[] args)
        {
            Deck player1Deck = new Deck();
            Deck player2Deck = new Deck();
            int p1RoundWinCount = 0;
            int p2RoundWinCount = 0;

            player1Deck.Shuffle();
            player2Deck.Shuffle();
            player2Deck.Shuffle();
            player2Deck.Shuffle();

            while (!(player1Deck.GetCards().Count.Equals(5) || player2Deck.GetCards().Count.Equals(5)))
            {
                Card p1Card = player1Deck.DrawTopCard();
                Card p2Card = player2Deck.DrawTopCard();
                Console.Write(p1Card.GetRank() + " of " + p1Card.GetSuit());
                Console.Write(" VS ");
                Console.Write(p2Card.GetRank() + " of " + p2Card.GetSuit());
                if (p1Card.GetRankValue() > p2Card.GetRankValue())
                {
                    p1RoundWinCount++;
                    Console.Write(" Player 1 wins round!");
                    player1Deck.AddCardToBottomOfDeck(p1Card);
                    player1Deck.AddCardToBottomOfDeck(p2Card);
                }
                else if (p1Card.GetRankValue() < p2Card.GetRankValue())
                {
                    p2RoundWinCount++;
                    Console.Write(" Player 2 wins round!");
                    player2Deck.AddCardToBottomOfDeck(p1Card);
                    player2Deck.AddCardToBottomOfDeck(p2Card);
                }
                else
                {
                    p1RoundWinCount++;
                    Console.Write("--- TIE ---");
                    player1Deck.AddCardToBottomOfDeck(p1Card);
                    player1Deck.AddCardToBottomOfDeck(p2Card);
                }
                Console.WriteLine("---");
            }

            if (player1Deck.GetCards().Count.Equals(0))
            {
                Console.WriteLine("layer 2 wins! Total rounds won: " + p1RoundWinCount.ToString());
            }
            else
            {
                Console.WriteLine("Player 1 wins! Total round won: " + p2RoundWinCount.ToString());
            }
        }
    }
}
