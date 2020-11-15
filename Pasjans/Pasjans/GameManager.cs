using System;
using System.Linq;
using Pasjans.PlayingCard;

namespace Pasjans
{
    class GameManager
    {
        public void StartGame()
        {
            var isWin = false;
            var table = new Table(new Deck());
            do
            {
                PrintTable(table);
                var userInput = Console.ReadLine();
                var spots = userInput.Split(" ");

                if ("RD".Equals(spots?[1], StringComparison.OrdinalIgnoreCase))
                {

                }else if ("RC".Equals(spots?[1], StringComparison.OrdinalIgnoreCase))
                {

                }else if ("S1".Equals(spots?[1], StringComparison.OrdinalIgnoreCase))
                {

                }else if ("S2".Equals(spots?[1], StringComparison.OrdinalIgnoreCase))
                {

                }else if ("S3".Equals(spots?[1], StringComparison.OrdinalIgnoreCase))
                {

                }else if ("S4".Equals(spots?[1], StringComparison.OrdinalIgnoreCase))
                {

                }

            } while (!isWin);
        }

        public Table MoveCard(Table table, int from, int to, Card card)
        {
            return table;
        }
        private void PrintTable(Table table)
        {
            var rd = "██";
            var rc = table.ReserveStock.Count > 0 ? table.ReserveStock.Last().ToString() : "  ";
            var s1 = table.FinalStock1.Count > 0 ? table.FinalStock1.Last().ToString() : "  ";
            var s2 = table.FinalStock2.Count > 0 ? table.FinalStock2.Last().ToString() : "  ";
            var s3 = table.FinalStock3.Count > 0 ? table.FinalStock3.Last().ToString() : "  ";
            var s4 = table.FinalStock4.Count > 0 ? table.FinalStock4.Last().ToString() : "  ";
            var N = new[]
            {
                table.Stock1.Count,
                table.Stock2.Count,
                table.Stock3.Count,
                table.Stock4.Count,
                table.Stock5.Count,
                table.Stock6.Count,
                table.Stock7.Count
            };

            Console.Clear();
            Console.WriteLine("__________________Solitaire________________________");
            Console.WriteLine($"  -RD-   -RC-          -S1-   -S2-   -S3-   -S4-  ");
            Console.WriteLine($" |{rd,3} |>|{rc,3} |        |{s1,3} | |{s2,3} | |{s3,3} | |{s4,3} | ");
            Console.WriteLine($"  ----   ----          ----   ----   ----   ----  ");
            Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ ");
            Console.WriteLine($"  - 1-   - 2-   - 3-   - 4-   - 5-   - 6-   - 7-  ");

            for (var i = 0; i < N.Max(); i++)
            {
                var c1 = i < N[0] ? $"|{table.Stock1[i].ToString(),3} |" : "      ";
                var c2 = i < N[1] ? $"|{table.Stock2[i].ToString(),3} |" : "      ";
                var c3 = i < N[2] ? $"|{table.Stock3[i].ToString(),3} |" : "      ";
                var c4 = i < N[3] ? $"|{table.Stock4[i].ToString(),3} |" : "      ";
                var c5 = i < N[4] ? $"|{table.Stock5[i].ToString(),3} |" : "      ";
                var c6 = i < N[5] ? $"|{table.Stock6[i].ToString(),3} |" : "      ";
                var c7 = i < N[6] ? $"|{table.Stock7[i].ToString(),3} |" : "      ";
                Console.WriteLine($" {c1} {c2} {c3} {c4} {c5} {c6} {c7} ");
            }

            Console.WriteLine("__________________________________________________");
            Console.WriteLine("Your move:");
        }
    }
}
