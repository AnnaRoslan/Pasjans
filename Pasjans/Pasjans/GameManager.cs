using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Pasjans.PlayingCard;

namespace Pasjans
{
    class GameManager
    {
        private Table _table;
        private CardMover _cardMover;

        public GameManager()
        {
            _cardMover = new CardMover();
            _table = new Table(new Deck());
        }

        public void StartGame()
        {
            var isWin = false;
            var error = "";
            do
            {
                PrintTable(_table, error);
                error = ProcessInput(Console.ReadLine());

            } while (!isWin);

            PrintWinnerBanner();
        }

        private string ProcessInput(string userInput)
        {
            var error = "";
            if (userInput == null)
                return error;

            var spots = userInput.Split(" ");
            if (spots.Length < 1)
                return error;

            if ("Undo".Equals(spots[0], StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    _table = _cardMover.UndoMove();
                }
                catch (Exception e)
                {
                    error= e.Message;
                }
            }else if ("RD".Equals(spots[0], StringComparison.OrdinalIgnoreCase))
            {
                if (_table.ReserveStock.Count > 0)
                {
                    try
                    {
                        _table = _cardMover.MoveCard(_table, 0, 0, _table.ReserveStock.Last());
                    }
                    catch (Exception e)
                    {
                        error = e.Message;
                    }
                }
                else
                {
                    error = "There is no more card on ReservedStock!";
                }
            }
            else if ("RC".Equals(spots[0], StringComparison.OrdinalIgnoreCase))
            {
                if (spots.Length > 1 && int.TryParse(spots[1], out var target) && target > 0 && target < 8)
                {
                    try
                    {
                        _table = _cardMover.MoveCard(_table, 0, target, _table.ReserveStock.Last());
                    }
                    catch (Exception e)
                    {
                        error = e.Message;
                    }
                }
                else
                {
                    error = "No valid target name for move. Try digit from 1 to 7.";
                }

            }
            else if (int.TryParse(spots[0], out var source) && source > 0 && source < 8)
            {
                if (spots.Length > 2 && int.TryParse(spots[1], out var target) && target > 0 && target < 8)
                {
                    try
                    {
                        CardValue? value = null;
                        Color? color = null;

                        if (spots[2].Length == 2)
                        {
                            value = char.ToUpper(spots[2][0]) switch
                            {
                                'A' => CardValue.Ace,
                                '2' => CardValue.Two,
                                '3' => CardValue.Three,
                                '4' => CardValue.Four,
                                '5' => CardValue.Five,
                                '6' => CardValue.Six,
                                '7' => CardValue.Seven,
                                '8' => CardValue.Eight,
                                '9' => CardValue.Nine,
                                'J' => CardValue.Jack,
                                'Q' => CardValue.Queen,
                                'K' => CardValue.King,
                                _ => throw new ArgumentException("Not valid name of the card to move")
                            };

                            color = char.ToUpper(spots[2][1]) switch
                            {
                                'H' => Color.Heart,
                                'D' => Color.Diamond,
                                'C' => Color.Club,
                                'S' => Color.Spade,
                                _ => throw new ArgumentException("Not valid name of the card to move")
                            };
                        }
                        else if (spots[2].Length == 3)
                        {
                            if (spots[2].Substring(0, 2) == "10")
                            {
                                value = CardValue.Ten;
                                color = char.ToUpper(spots[2][2]) switch
                                {
                                    'H' => Color.Heart,
                                    'D' => Color.Diamond,
                                    'C' => Color.Club,
                                    'S' => Color.Spade,
                                    _ => throw new ArgumentException("Not valid name of the card to move")
                                };
                            }
                            else
                            {
                                throw new ArgumentException("Not valid name of the card to move");
                            }
                        }
                        else
                        {
                            error = "Not valid name of the card to move.";
                        }

                        if (value != null && color != null)
                        {
                            _table = _cardMover.MoveCard(_table, source, target, new Card((CardValue)value, (Color)color));
                        }
                    }
                    catch (Exception e)
                    {
                        error = e.Message;
                    }
                }
                else
                {
                    error = "No valid target name for move. Try digit from 1 to 7.";
                }
            }
            else
            {
                error = "No valid source name for move. Try digit from 1 to 7, RD or RC.";
            }

            return error;
        }

        private void PrintTable(Table table, string error)
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
            var sb = new StringBuilder();
            sb.Append("__________________Solitaire_______________________\n");
            sb.Append($"  -RD-   -RC-          -S1-   -S2-   -S3-   -S4-  \n");
            sb.Append($" |{rd,3} |>|{rc,3} |        |{s1,3} | |{s2,3} | |{s3,3} | |{s4,3} | \n");
            sb.Append($"  ----   ----          ----   ----   ----   ----  \n");
            sb.Append("_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ \n");
            sb.Append($"  - 1-   - 2-   - 3-   - 4-   - 5-   - 6-   - 7-  \n");

            for (var i = 0; i < N.Max(); i++)
            {
                var c1 = i < N[0] ? $"|{table.Stock1[i].ToString(),3} |" : "      ";
                var c2 = i < N[1] ? $"|{table.Stock2[i].ToString(),3} |" : "      ";
                var c3 = i < N[2] ? $"|{table.Stock3[i].ToString(),3} |" : "      ";
                var c4 = i < N[3] ? $"|{table.Stock4[i].ToString(),3} |" : "      ";
                var c5 = i < N[4] ? $"|{table.Stock5[i].ToString(),3} |" : "      ";
                var c6 = i < N[5] ? $"|{table.Stock6[i].ToString(),3} |" : "      ";
                var c7 = i < N[6] ? $"|{table.Stock7[i].ToString(),3} |" : "      ";
                sb.Append($" {c1} {c2} {c3} {c4} {c5} {c6} {c7} \n");
            }
            sb.Append("__________________________________________________\n");
            sb.Append(error+ "\n");
            sb.Append("Your move:");
            Console.WriteLine(sb);
        }

        private void PrintWinnerBanner()
        {
            Console.Clear();
            Console.Clear();
            var sb = new StringBuilder();
            sb.Append("__________________Solitaire_______________________\n");
            sb.Append("\n                   You won!\n\n");
            sb.Append("__________________________________________________\n");

            Console.WriteLine(sb);
        }
    }
}
