using System;
using System.Collections.Generic;
using System.Text;

namespace Pasjans
{
    public class Deck
    {
        public List<Card> DeckCards  = new List<Card>();

        public Deck()
        {
            for (int i = 0; i < 52; i++)
            {
                DeckCards.Add(new Card(CardValue.Ace,Color.Club));
            }
        }
        

    }
}
