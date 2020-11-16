using System;
using System.Collections.Generic;
using System.Linq;
using Pasjans.PlayingCard;

namespace Pasjans
{
    public class CardMover
    {
        private List<Table> _tableHistory = new List<Table>();
        public Table UndoMove()
        {
            if (_tableHistory.Count == 0)
            {
                throw new Exception("Can not undo move. No more previous moves.");
            }

            var lastTable = _tableHistory.Last();
            _tableHistory.RemoveAt(_tableHistory.Count - 1);

            return lastTable;
        }
        public Table MoveCard(Table table, int from, int to, Card card)
        {
            if (table != null)
            {
                _tableHistory.Add(table.Clone());
            }
            else
            {
                throw new ArgumentException("Table can not be null.");
            }

            if (from == 0 && to == 0)
            {
                return GetNewCardFromReserveStock(table);
            }

            if (card == null)
            {
                throw new ArgumentException("Card can not be null.");
            }

            if (to == 0)
            {
                throw new ArgumentException("Can not move to reserve stock from another stock.");
            }

            var fromStock = GetStock(table, from);
            var toStock = GetStock(table, to);

            if (!fromStock.Any(x => x.CardValue == card.CardValue && x.Color == card.Color))
            {
                throw new ArgumentException("This card is not present in given stock.");
            }

            var cardToMoveIndex = fromStock.IndexOf(fromStock.Find(x => x.CardValue == card.CardValue && x.Color == card.Color));
            var moveMultiple = cardToMoveIndex != fromStock.Count - 1 && from != 0;

            if (!fromStock[cardToMoveIndex].IsReversed)
            {
                throw new ArgumentException("Can not move not reversed card.");
            }

            if (toStock.Count != 0)
            {
                var lastCard = toStock[^1];

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
            }
            
            var cardsToMove = fromStock.GetRange(cardToMoveIndex, fromStock.Count - cardToMoveIndex);
            fromStock.RemoveRange(cardToMoveIndex, fromStock.Count - cardToMoveIndex);
            toStock.AddRange(cardsToMove);

            Revert(fromStock);

            MoveToFinal(table);
            
            return table;
        }

        private bool CanLayCardOnOther(Card lastCard, Card cardToMove)
        {
            if ((int)lastCard.CardValue - (int)cardToMove.CardValue != 1)
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

        private void MoveToFinal(Table table)
        {
            var noRequiredCardsToFinal = 13;
            var stockList = new List<List<Card>>
            {
                table.Stock1,
                table.Stock2,
                table.Stock3,
                table.Stock4,
                table.Stock5,
                table.Stock6,
                table.Stock7
            };

            var finalStocks = new List<List<Card>>
            {
                table.FinalStock1, 
                table.FinalStock2,
                table.FinalStock3,
                table.FinalStock4
            };

            var firstFreeFinalStock = finalStocks.FirstOrDefault(x => x.Count == 0);

            if (firstFreeFinalStock == null)
            {
                throw new Exception("All stocks are full, you won!");
            }

            stockList.ForEach(stock =>
            {
                if (stock.Count >= noRequiredCardsToFinal)
                {
                    var canMove = true;

                    for (var i = stock.Count - noRequiredCardsToFinal; i < stock.Count; i++)
                    {
                        canMove &= CanMoveMultipleCards(i, stock);
                    }

                    if (canMove)
                    {
                        var cardsToMove = stock.GetRange(stock.Count - noRequiredCardsToFinal, noRequiredCardsToFinal);
                        stock.RemoveRange(stock.Count - noRequiredCardsToFinal, noRequiredCardsToFinal);
                        firstFreeFinalStock.AddRange(cardsToMove);
                    }
                }
            });

            if (finalStocks.All(x => x.Count == noRequiredCardsToFinal))
            {
                table.IsGameWon = true;
            }
        }

        private Table GetNewCardFromReserveStock(Table table)
        {
            var reserveStock = table.ReserveStock;

            var lastReserveCard = reserveStock.Last();
            lastReserveCard.IsReversed = false;
            reserveStock.Remove(lastReserveCard);
            reserveStock.Last().IsReversed = true;
            reserveStock.Insert(0, lastReserveCard);

            return table;
        }

        private List<Card> GetStock(Table table, int stockNumber)
        {
            var stock = stockNumber switch
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

            return stock;
        }

        private void Revert(List<Card> stock)
        {
            if (!stock.Any(x => x.IsReversed) && stock.Count != 0)
            {
                stock[^1].IsReversed = true;
            }
        }
    }
}