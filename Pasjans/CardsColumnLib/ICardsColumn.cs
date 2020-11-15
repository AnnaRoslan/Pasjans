using System.Collections.Generic;
using CardPack;

namespace CardsColumnLib
{
    public interface ICardsColumn
    {
        List<Card> GetVisibleCards();
        List<Card> PeekTopVisibleCards(int n);
        List<Card> TakeTopVisibleCards(int n);
        void PutCards(List<Card> cards);
    }
}