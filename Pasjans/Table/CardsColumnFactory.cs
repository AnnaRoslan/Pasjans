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

            if (columnCapacity < 1)
            {
                throw new ArgumentException("ColumnCapacity cannot be less than 1.");
            }

            if (columnCapacity > cardPack.Count)
            {
                throw new ArgumentException("ColumnCapacity cannot be bigger than cardPack count.");
            }

            var hiddenCards = cardPack.GetRange(cardPack.Count - columnCapacity, columnCapacity - 1);
            var visibleCards = cardPack.GetRange(cardPack.Count - 1, 1);

            cardPack.RemoveRange(cardPack.Count - columnCapacity, columnCapacity);

            return new CardsColumn(hiddenCards, visibleCards);
        }
    }
}