using System;
using System.Collections.Generic;
using Pasjans.PlayingCard;

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
                Color color = (Color) i;

                for (int j = 1; j <= 13; j++)
                {
                    var value = (CardValue) j;
                    DeckCards.Add(new Card(value, color));
                }
            }

            Shuffle();
        }

        private void Shuffle()
        {
            Random rng = new Random();
            int n = DeckCards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = DeckCards[k];
                DeckCards[k] = DeckCards[n];
                DeckCards[n] = value;
            }
        }
    }
}