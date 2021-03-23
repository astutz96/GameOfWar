using System;
using CardGames;
using System.Collections.Generic;


namespace GameOfWar
{
    class GameOfWar
    {
        public List<Card> P1Hand { get; set; }
        public List<Card> P2Hand { get; set; }

        public List<Card> WinnersPot { get; set; }

        public Card P1CardInPlay { get; set; }

        public Card P2CardInPlay { get; set; }
    }
}