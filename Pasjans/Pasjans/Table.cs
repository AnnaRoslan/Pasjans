using System;
using System.Collections.Generic;
using System.Linq;
using Pasjans.PlayingCard;

namespace Pasjans
{
    [Serializable]
    public class Table
    {
        public List<Card> ReserveStock { get; set; }
        public List<Card> FinalStock1 { get; set; }
        public List<Card> FinalStock2 { get; set; }
        public List<Card> FinalStock3 { get; set; }
        public List<Card> FinalStock4 { get; set; }

        public List<Card> Stock1 { get; set; }
        public List<Card> Stock2 { get; set; }
        public List<Card> Stock3 { get; set; }
        public List<Card> Stock4 { get; set; }
        public List<Card> Stock5 { get; set; }
        public List<Card> Stock6 { get; set; }
        public List<Card> Stock7 { get; set; }

        public Table()
        {
            ReserveStock = new List<Card>();

            FinalStock1 = new List<Card>();
            FinalStock2 = new List<Card>();
            FinalStock3 = new List<Card>();
            FinalStock4 = new List<Card>();

            Stock1 = new List<Card>();
            Stock2 = new List<Card>();
            Stock3 = new List<Card>();
            Stock4 = new List<Card>();
            Stock5 = new List<Card>();
            Stock6 = new List<Card>();
            Stock7 = new List<Card>();
        }

        public Table(Deck deck) : this()
        {
            Stock1.AddRange(deck.DeckCards.GetRange(24, 1));
            Stock1.Last().IsReversed = true;

            Stock2.AddRange(deck.DeckCards.GetRange(25, 2));
            Stock2.Last().IsReversed = true;

            Stock3.AddRange(deck.DeckCards.GetRange(27, 3));
            Stock3.Last().IsReversed = true;

            Stock4.AddRange(deck.DeckCards.GetRange(30, 4));
            Stock4.Last().IsReversed = true;

            Stock5.AddRange(deck.DeckCards.GetRange(34, 5));
            Stock5.Last().IsReversed = true;

            Stock6.AddRange(deck.DeckCards.GetRange(39, 6));
            Stock6.Last().IsReversed = true;

            Stock7.AddRange(deck.DeckCards.GetRange(45, 7));
            Stock7.Last().IsReversed = true;

            ReserveStock.AddRange(deck.DeckCards.GetRange(0, 24));
            ReserveStock.Last().IsReversed = true;
        }

        public override bool Equals(object? obj)
        {
            if ((obj == null) || this.GetType() != obj.GetType())
            {
                return false;
            }

            var other = (Table) obj;

            var stocks = new List<List<Card>>
            {
                Stock1, Stock2, Stock3, Stock4, Stock5, Stock6, Stock7, FinalStock1, FinalStock2, FinalStock3,
                FinalStock4,
                ReserveStock
            };
            var otherStocks = new List<List<Card>>
            {
                other.Stock1, other.Stock2, other.Stock3, other.Stock4, other.Stock5, other.Stock6, other.Stock7, other.FinalStock1, 
                other.FinalStock2, other.FinalStock3, other.FinalStock4, other.ReserveStock
            };

            var result = true;

            for (var i = 0; i < stocks.Count; i++)
            {
                result &= stocks[i].Count == otherStocks[i].Count;

                if (!result)
                {
                    break;
                }

                for (var j = 0; j < stocks[i].Count; j++)
                {
                    result &= stocks[i][j].Equals(otherStocks[i][j]);
                }
            }

            return result;
        }
    }
}