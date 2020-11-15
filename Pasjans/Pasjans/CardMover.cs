using System;
using System.Collections.Generic;
using System.Linq;
using Pasjans.PlayingCard;

namespace Pasjans
{
    public class CardMover
    {
        public CardMover()
        {

        }

        public Table MoveCard(Table table, int from, int to, Card card)
        {
            var fromStock = from switch
            {
                0 => table.ReserveStock,
                1 => table.Stock1,
                2 => table.Stock2,
                3 => table.Stock3,
                4 => table.Stock4,
                5 => table.Stock5,
                6 => table.Stock6,
                7 => table.Stock7,
                _ => throw new ArgumentException("Given stock does not exist.")
            };

            var toStock = to switch
            {
                1 => table.Stock1,
                2 => table.Stock2,
                3 => table.Stock3,
                4 => table.Stock4,
                5 => table.Stock5,
                6 => table.Stock6,
                7 => table.Stock7,
                _ => throw new ArgumentException("Given stock does not exist.")
            };

            if (!fromStock.Any(x => x.CardValue == card.CardValue && x.Color == card.Color))
            {
                throw new ArgumentException("This card is not present in given stock.");
            }

            var lastCard = toStock[^1];
            var cardToMoveIndex = fromStock.IndexOf(fromStock.Find(x => x.CardValue == card.CardValue && x.Color == card.Color));
            var moveMultiple = cardToMoveIndex != fromStock.Count - 1 && from != 0;

            if (!fromStock[cardToMoveIndex].IsReversed)
            {
                throw new ArgumentException("Can not move not reversed card.");
            }

            if (!CanLayCardOnOther(lastCard, card))
            {
                throw new ArgumentException("Can not move this card.");
            }

            if (moveMultiple)
            {
                if (!CanMoveMultipleCards(cardToMoveIndex, fromStock))
                {
                    throw new ArgumentException("Can not move cards in the following order.");
                }
            }

            var cardsToMove = fromStock.GetRange(cardToMoveIndex, fromStock.Count - cardToMoveIndex);
            fromStock.RemoveRange(cardToMoveIndex, fromStock.Count - cardToMoveIndex);
            toStock.AddRange(cardsToMove);

            if (!fromStock.Any(x => x.IsReversed) && fromStock.Count != 0)
            {
                fromStock[^1].IsReversed = true;
            }

            return table;
        }

        private bool CanLayCardOnOther(Card lastCard, Card cardToMove)
        {
            if ((int)lastCard.CardValue <= (int)cardToMove.CardValue)
            {
                return false;
            }

            return (int)lastCard.Color % 2 != (int)cardToMove.Color % 2;
        }

        private bool CanMoveMultipleCards(int index, List<Card> stock)
        {
            var result = true;

            for (var i = index; i < stock.Count - 1; i++)
            {
                result &= CanLayCardOnOther(stock[i], stock[i + 1]);
            }

            return result;
        }
    }
}