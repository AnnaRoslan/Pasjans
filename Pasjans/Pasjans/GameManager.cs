using System;
using System.Collections.Generic;

namespace Pasjans
{
    class GameManager
    {
        public void StartGame()
        {
            var isWin = false;
            do
            {
                PrintBoard(null);
                var userInput = Console.ReadLine();
                var spots = userInput.Split(" ");

            } while (!isWin);
        }

        private void PrintBoard(List<string> board)
        {
            var fd = "XX";
            var fc = "  ";
            var s1 = "1Ż";
            var s2 = "1Ż";
            var s3 = "1Ż";
            var s4 = "1Ż";
            var n = 5;


            Console.Clear();
            Console.WriteLine("__________________Solitaire________________________");
            Console.WriteLine($"  -FD-   -FC-          -S1-   -S2-   -S3-   -S4-  ");
            Console.WriteLine($" | {fd} |>| {fc} |        | {s1} | | {s2} | | {s3} | | {s4} | ");
            Console.WriteLine($"  ----   ----          ----   ----   ----   ----  ");
            Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ ");
            Console.WriteLine($"  - 1-   - 2-   - 3-   - 4-   - 5-   - 6-   - 7-  ");

            for (var i = 0; i < n; i++)
            {
                var c1 = "| 2C |";
                var c2 = "| XX |";
                var c3 = "| 2C |";
                var c4 = "| XX |";
                var c5 = "| XX |";
                var c6 = "| 2C |";
                var c7 = "| XX |";
                Console.WriteLine($" {c1} {c2} {c3} {c4} {c5} {c6} {c7} ");
            }


            Console.WriteLine($" | 2C | | XX | | XX | | XX | | XX | | XX | | XX | ");
            Console.WriteLine($" |    | | 2C | | XX | | XX | | XX | | XX | | XX | ");
            Console.WriteLine($" |    | |    | | 2C | | XX | | XX | | XX | | XX | ");
            Console.WriteLine($" |    | |    | |    | | 2C | | XX | | XX | | XX | ");
            Console.WriteLine($" |    | |    | |    | |    | | 2C | | XX | | XX | ");
            Console.WriteLine($" |    | |    | |    | |    | |    | | 2C | | XX | ");
            Console.WriteLine($" |    | |    | |    | |    | |    | |    | | 2C | ");

            Console.WriteLine("__________________________________________________");
            Console.WriteLine("Your move:");
        }
    }
}
