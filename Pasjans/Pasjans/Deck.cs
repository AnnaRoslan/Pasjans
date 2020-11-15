using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Pasjans
{
    public class Deck
    {
        public List<Card> DeckCards { get; set; }

        public Deck()
        {
            DeckCards = new List<Card>();
            for (int i = 0; i < 4; i++)
            {
                Color color = (Color)i;

                for (int j = 1; j <= 13; j++)
                {
                    var value = (CardValue) j;
                    DeckCards.Add( new Card(value,color));
                }
            }
        }
    }
}
