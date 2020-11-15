using System;
using System.Collections.Generic;
using CardPack;

namespace Table
{
    public class CardsColumnFactory : ICardsColumnFactory
    {
        public CardsColumn Create(List<Card> cardPack, int columnCapacity)
        {
            if (cardPack == null)
            {
                throw new ArgumentException("CardPack cannot be null.");
            }

            return null;
        }
    }
}