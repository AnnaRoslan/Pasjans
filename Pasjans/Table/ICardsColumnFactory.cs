using System.Collections.Generic;
using CardPack;

namespace Table
{
    public interface ICardsColumnFactory
    {
        CardsColumn Create(List<Card> cardPack, int columnCapacity);
    }
}