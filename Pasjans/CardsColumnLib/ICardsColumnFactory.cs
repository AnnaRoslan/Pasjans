using System.Collections.Generic;
using CardPack;

namespace CardsColumnLib
{
    public interface ICardsColumnFactory
    {
        CardsColumn Create(List<Card> cardPack, int columnCapacity);
    }
}