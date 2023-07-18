using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Learning
{
    public class Card
    {
        public string Suit { get; set; }
        public string Rank { get; set; }

        public Card(string setSuit, string setRank)
        {
            Suit = setSuit;
            Rank = setRank;
        }

        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }
    }
}
