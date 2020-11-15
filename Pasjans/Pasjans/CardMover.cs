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

            return table;
        }
    }
}