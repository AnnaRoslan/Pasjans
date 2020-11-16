using Pasjans.PlayingCard;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Pasjans
{
    public class Column
    {
        //it named stock_x
        public List<Card> possibleCards { get; set; }
        public int colIndex { get; set; }

        public Column(int colIndex, Table table)
        {
            this.colIndex = colIndex;
            this.possibleCards = colIndex switch
            {
                1 => table.Stock1,
                2 => table.Stock2,
                3 => table.Stock3,
                4 => table.Stock4,
                5 => table.Stock5,
                6 => table.Stock6,
                7 => table.Stock7,
                _ => throw new ArgumentException("Cant retrieve column - wrong number")
            };
        }

        //adding FinalStocks, and control final state(game over)
        public List<bool> checkConclusion(Table table)
        {
            if (possibleCards.Count >= 13 && isDeleteable(possibleCards))
            {

                //range of cards to add to the first free final stock
                List<Card> transferRange = possibleCards.GetRange(this.possibleCards.Count - 13, 13);

                this.possibleCards.RemoveRange(this.possibleCards.Count - 13, 13);

                if (table.FinalStock1.Count == 0)
                {
                    table.FinalStock1.AddRange(transferRange);

                    return new List<bool> { true, false };
                }
                else if (table.FinalStock2.Count == 0)
                {
                    table.FinalStock2.AddRange(transferRange);

                    return new List<bool> { true, false };
                }
                else if (table.FinalStock3.Count == 0)
                {
                    table.FinalStock3.AddRange(transferRange);

                    return new List<bool> { true, false };
                }
                else if (table.FinalStock4.Count == 0)
                {
                    //let to know Table, that this is over
                    table.FinalStock4.AddRange(transferRange);
                    table.isGameFinished = true;
                    return new List<bool> { true, true };
                }
                else throw new Exception("Unrecognized error has occured");

            }else
            {
                return new List<bool> { false, false };
            }



        }

        public bool isDeleteable(List<Card> someRange)
        {
            for (int i = 0; i < someRange.Count; i++)
            {
                if (someRange[i].IsReversed == true)
                {
                    return false;
                }

                for (int j = i + 1; j < someRange.Count; j++)
                {
                    if (((int)someRange[i].Color % 2 != (int)someRange[j].Color % 2))
                    {
                        return false;
                    }

                    if (j == i + 1 && Math.Abs(someRange[i].CardValue - someRange[j].CardValue) != 1)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}

   
