using System.Collections.Generic;
using System.Linq;
using Pasjans.PlayingCard;

namespace Pasjans
{
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
            Stock1.AddRange(deck.DeckCards.GetRange(24,1));
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

    }

}
