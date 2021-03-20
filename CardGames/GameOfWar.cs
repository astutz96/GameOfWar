using System;
using CardGames;
using System.Collections.Generic;


namespace GameOfWar
{
    class GameOfWar
    {
        private List<Card> p1Hand;
        private List<Card> p2Hand;
        private List<Card> winnersPot;
        private Card p1CardInPlay;
        private Card p2CardInPlay;

        public List<Card> P1Hand
        {
            get { return p1Hand; }
            set { p1Hand = value; }
        }

        public List<Card> P2Hand
        {
            get { return p2Hand; }
            set { p2Hand = value; }
        }

        public List<Card> WinnersPot
        {
            get { return winnersPot; }
            set { winnersPot = value; }
        }

        public Card P1CardInPlay
        {
            get { return p1CardInPlay; }
            set { p1CardInPlay = value; }
        }

        public Card P2CardInPlay
        {
            get { return p2CardInPlay; }
            set { p2CardInPlay = value; }
        }
    }
}

