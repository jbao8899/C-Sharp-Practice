using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Learning
{
    public class Deck
    {
        public List<Card> cards; 

        public Deck()
        {
            cards = new List<Card>();
        }

        public void GetCards()
        {
            cards.Clear();
            foreach (string suit in (new string[] { "Hearts", "Diamonds", "Spades", "Clubs" }))
            {
                foreach (string rank in (new string[] { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" }))
                {
                    cards.Add(new Card(suit, rank));
                }
            }
        }

        public void Shuffle()
        {
            Random random = new Random();
            cards = (from card in cards
                     orderby random.Next()
                     select card).ToList(); // return cards in random order
        }

        public List<Card> Deal(int handSize)
        {
            if (0 >= handSize || handSize > cards.Count)
            {
                throw new ArgumentException("The hand size must be a positive integer that is less than the remaining deck size");
            }

            // deck shuffled, don't need randomness here
            List<Card> hand = new List<Card>();
            for (int i = 0; i < handSize; i++)
            {
                hand.Add(cards[cards.Count - 1]);
                cards.RemoveAt(cards.Count - 1);
            }

            return hand;
        }
    }
}