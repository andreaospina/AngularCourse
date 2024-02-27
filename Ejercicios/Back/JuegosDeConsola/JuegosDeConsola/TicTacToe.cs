using JuegosDeConsola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegosDeConsola
{
    internal class TicTacToe
    {
        public const char DIAG1_IDENTIFIER = 'D';
        public const char DIAG2_IDENTIFIER = 'E';
        public const string MACHINE_NAME = "Machine gamer";
        public const string GAME_NAME = "Tic-Tac-Toe";
        public const string GAME_RULES = @"""
            You need to play agains another player, you can decide if it is another player or the machine.
            You are the player with the icon X, the second player will be the icon O 
            The objective is to create a line of 3 icons together, in a grid of 3x3.
            The line could be: horizontal, vertical or diagonal. The one who achives this first will be the winner.
            To chooose a position you need to know the following instructions:
                * Choose a leter between the A, B or C to choose which row you want to play.
                * Choose a number between the 1, 2 or 3 to choose which column you want to play.
                * You cannot choose a position that is already played.
        """;
        public enum players
        {
            player1 = 'X',
            player2 = 'O'
        }

        private Utilities utilities = new Utilities();
        private TicTacToeConfig config = new TicTacToeConfig();

        public void Start(string playerName)
        {

            var playAgain = "";
            do
            {
                config.PlayerName = playerName;
                utilities.PrintGameWelcome(config.PlayerName, GAME_NAME, GAME_RULES);
                CleanGame();
                PlayGame();
                Console.WriteLine("Do you want to play again? Y/N");
                playAgain = Console.ReadLine();

            } while (playAgain.ToLower() == "y");

        }

        private void PlayGame()
        {
            DefinePlayer2();
            Console.WriteLine();
            Console.Write("Ok, Let's start the game !!");
            if (config.Dificulty == "Hard")
            {
                utilities.PrintInColor("    >:)");
            }
            Console.WriteLine();
            Thread.Sleep(1700); // Pause the execution x miliseconds
            while (!config.RoundIsOver)
            {
                config.RoundIsOver = PlayRound(players.player1, config.PlayerName);
                if (config.RoundIsOver == true)
                    break;

                config.RoundIsOver = PlayRound(players.player2, config.PlayerName2);
                if (config.RoundIsOver == true)
                    break;

            }

        }

        private void DefinePlayer2()
        {
            var option = "";
            while (config.PlayerName2 == "")
            {
                Console.WriteLine("Do you want to play with another player or the machine. \n 1: to play with the machine. \n 2: to play with another player.");
                option = Console.ReadLine();
                if (option == "1")
                {
                    config.PlayerName2 = MACHINE_NAME;
                    Console.WriteLine("Please select the dificulty.\n Choose 1: Easy, 2: Hard");
                    var dif = Console.ReadLine();
                    if (dif == "1")
                    {
                        config.Dificulty = "Easy";
                    }
                    else if (dif == "2")
                    {
                        config.Dificulty = "Hard";
                    }
                    else
                    {
                        Console.WriteLine("You select an invalid option for the dificulty. Please try again.");
                        config.PlayerName2 = "";
                        continue;
                    }
                }
                else if (option == "2")
                {
                    Console.WriteLine("Please type the name of player 2.");
                    var name2 = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(name2))
                    {
                        Console.WriteLine("Please type a right player name");
                    }
                    else if (name2 == MACHINE_NAME)
                    {
                        Console.WriteLine("Please type another player name. The name choosen is restricted.");
                    }
                    else
                    {
                        config.PlayerName2 = name2;
                    }
                }
                else
                {
                    Console.WriteLine("Please select a valid option.");
                }
            }
        }

        private bool PlayRound(players player, string playerName)
        {

            if (config.RoundsCounter > 9)
            {
                Console.WriteLine("It is a DRAW. Try one more time !");
                return true;
            }
            Console.Clear();
            var playerWon = false;
            PrintTemplate();
            ChangeToPlayer(player, playerName);
            var move = "";
            if (playerName == MACHINE_NAME)
            {
                if (config.Dificulty == "Hard")
                {
                    move = GetMachineMoveSmarter();
                }
                else
                {
                    move = GetMachineMoveDumb();
                }
                Console.WriteLine(move);
                Thread.Sleep(1500);
            }
            else
            {
                move = GetUserMove();
            }
            config.AvailableOptions.Remove(move);

            UpdateTemplate(player, move);
            var isWinner = IdentifyWinner1(move);
            if (isWinner)
            {
                playerWon = true;
                Console.Clear();
                PrintTemplate();
                if (playerName == MACHINE_NAME)
                {
                    utilities.PrintLoser(config.PlayerName);
                }
                else
                {

                    utilities.PrintWinner(playerName);
                }
            }
            config.RoundsCounter++;
            return playerWon;
        }

        private void UpdateTemplate(players player, string move)
        {
            var row = ConvertMoveToIndex(move[0]);
            var col = ConvertMoveToIndex(move[1]);
            config.GameTemplate[row, col] = ((char)player).ToString();

            config.Movements[move[0]] += 1; // To control rows
            config.Movements[move[1]] += 1; // To control cols
            if (config.Diag1.Contains(move))
            {
                config.Movements[DIAG1_IDENTIFIER]++;
            }
            if (config.Diag2.Contains(move))
            {
                config.Movements[DIAG2_IDENTIFIER]++;
            }
        }

        private bool IdentifyWinner1(string move)
        {
            var row = move[0];
            var rowIdx = ConvertMoveToIndex(row);
            var col = move[1];
            var colIdx = ConvertMoveToIndex(col);

            // check on rows direction
            if (config.Movements[row] == 3)
            {
                if (config.GameTemplate[rowIdx, 0] == config.GameTemplate[rowIdx, 1] && config.GameTemplate[rowIdx, 0] == config.GameTemplate[rowIdx, 2])
                {
                    return true;
                }
            }

            // check on cols direction
            if (config.Movements[col] == 3)
            {
                if (config.GameTemplate[0, colIdx] == config.GameTemplate[1, colIdx] && config.GameTemplate[0, colIdx] == config.GameTemplate[2, colIdx])
                {
                    return true;
                }
            }

            // check on diags
            if (config.Diag1.Contains(move))
            {
                if (config.Movements[DIAG1_IDENTIFIER] == 3)
                {
                    if (config.GameTemplate[0, 0] == config.GameTemplate[1, 1] && config.GameTemplate[0, 0] == config.GameTemplate[2, 2])
                    {
                        return true;
                    }
                }
            }

            if (config.Diag2.Contains(move))
            {
                if (config.Movements[DIAG2_IDENTIFIER] == 3)
                {
                    if (config.GameTemplate[0, 2] == config.GameTemplate[1, 1] && config.GameTemplate[0, 2] == config.GameTemplate[2, 0])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void PrintTemplate()
        {
            PrintForPlayer(players.player1, config.PlayerName);
            Console.Write(" vs ");
            PrintForPlayer(players.player2, config.PlayerName2);
            Console.WriteLine();

            Console.WriteLine("     1       2       3"); // Column indicators

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("        |       |       ");

                Console.Write($"{ConvertIndexToRowMove(i)}   "); // Print row indicators
                PrintCell(config.GameTemplate[i, 0]);
                Console.Write("   |   ");
                PrintCell(config.GameTemplate[i, 1]);
                Console.Write("   |   ");
                PrintCell(config.GameTemplate[i, 2]);
                Console.WriteLine();
                if (i < 2)
                {
                    Console.WriteLine("   _____|_______|_______");
                }
                else
                {
                    Console.WriteLine("        |       |       ");
                }
            }
        }

        private void PrintCell(string cellContent)
        {
            if (cellContent == "X")
            {
                PrintForPlayer(players.player1, cellContent);
            }
            else if (cellContent == "O")
            {
                PrintForPlayer(players.player2, cellContent);
            }
            else
            {
                Console.Write(cellContent);
            }

        }

        private void ChangeToPlayer(players player, string playerName)
        {
            Console.WriteLine();
            PrintForPlayer(player, playerName);
            Console.WriteLine(" is playing.");
        }

        private void PrintForPlayer(players player, string text)
        {
            if (player == players.player1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.Write(text);
            Console.ResetColor();

        }

        private string GetMachineMoveDumb()
        {
            Thread.Sleep(1500);
            var machineMoveIndex = new Random().Next(0, config.AvailableOptions.Count);
            var option = config.AvailableOptions[machineMoveIndex];            
            return option;
        }
        private string GetMachineMoveSmarter()
        {
            var result = "";
            Thread.Sleep(1500);
            var posivilities = config.Movements.Where(p => p.Value == 2).ToList(); // Filter all the values == 2
            if (posivilities.Any())
            {
                foreach (var item in posivilities)
                {

                    if (item.Key == DIAG1_IDENTIFIER)
                    {
                        if (config.GameTemplate[0, 0] == config.GameTemplate[1, 1] || config.GameTemplate[0, 0] == config.GameTemplate[2, 2] || config.GameTemplate[1, 1] == config.GameTemplate[2, 2])
                        {
                            result = config.AvailableOptions.Find(p => config.Diag1.Contains(p));
                            break;
                        }
                    }
                    else if (item.Key == DIAG2_IDENTIFIER)
                    {
                        if (config.GameTemplate[0, 2] == config.GameTemplate[1, 1] || config.GameTemplate[0, 2] == config.GameTemplate[2, 0] || config.GameTemplate[1, 1] == config.GameTemplate[2, 0])
                        {
                            result = config.AvailableOptions.Find(p => config.Diag2.Contains(p));
                            break;
                        }
                    }
                    else if (char.IsDigit(item.Key)) // posivility in column direction
                    {
                        var idx = ConvertMoveToIndex(item.Key);

                        if (config.GameTemplate[0, idx] == config.GameTemplate[1, idx] || config.GameTemplate[0, idx] == config.GameTemplate[2, idx] || config.GameTemplate[1, idx] == config.GameTemplate[2, idx])
                        {
                            result = config.AvailableOptions.Find(p => p.Contains(item.Key));
                            break;
                        }
                    }
                    else // Row 
                    {
                        var idx = ConvertMoveToIndex(item.Key);

                        if (config.GameTemplate[idx, 0] == config.GameTemplate[idx, 1] || config.GameTemplate[idx, 0] == config.GameTemplate[idx, 2] || config.GameTemplate[idx, 1] == config.GameTemplate[idx, 2])
                        {
                            result = config.AvailableOptions.Find(p => p.Contains(item.Key));
                            break;
                        }
                    }
                }
                if (result == "") // No good options
                {
                    result = GetMachineMoveDumb();
                }
            }
            else
            {
                var center = config.AvailableOptions.FirstOrDefault(p => p == "B2");
                if (center is not null)
                {
                    result = center;
                }
                else
                {
                    result = GetMachineMoveDumb();
                }
            }
            return result;
        }

        private string GetUserMove()
        {
            var userMove = "";
            while (IsMoveValid(userMove) == false)
            {
                Console.WriteLine("Please choose a position: A, B or C to choose the row, and 1, 2 or 3 for the column: ");
                userMove = Console.ReadLine().ToUpper();
            }
            return userMove;
        }

        private bool IsMoveValid(string move)
        {
            // Move: A1, A3
            if (string.IsNullOrWhiteSpace(move))
            {
                return false;
            }
            if (move.Length != 2)
            {
                Console.WriteLine("Please remember, the format of the move is the letter to represent the columna and a number to represent the row.\n Example: A2");
                return false;
            }
            if (config.ValidRows.Contains(move[0].ToString()) == false) // Row is invalid
            {
                Console.WriteLine("Please remember, the row should be represented with A, B or C.\n Example: A2");
                return false;
            }

            if (config.ValidColumns.Contains(move[1].ToString()) == false) // Column is invvalid
            {
                Console.WriteLine("Please remember, the column should be represented with 1, 2 or 3.\n Example: A2");
                return false;
            }

            if (!config.AvailableOptions.Contains(move)) // Move is busy
            {
                Console.WriteLine("Please remember, you cannot select an already played move, please choose anotherone.");
                return false;
            }

            return true;
        }


        private void CleanGame()
        {
            //config.availableOptions = new() { "A1", "A2", "A3", "B1", "B2", "B3", "C1", "C2", "C3" };
            //config.gameTemplate = new string[3, 3] {
            //    {" ", " ", " "},
            //    {" ", " ", " "},
            //    {" ", " ", " "}
            //};
            //config.movements = new()
            //{
            //    { 'A', 0 },
            //    { 'B', 0 },
            //    { 'C', 0 },
            //    { '1', 0 },
            //    { '2', 0 },
            //    { '3', 0 },
            //    { DIAG1_IDENTIFIER, 0 },
            //    { DIAG2_IDENTIFIER, 0 },
            //};
            //config.RoundIsOver = false;
            //config.roundsCounter = 1;
            //config.playerName2 = "";

            config = new TicTacToeConfig();
        }

        private int ConvertMoveToIndex(char move) => move switch
        {
            'A' => 0,
            'B' => 1,
            'C' => 2,
            '1' => 0,
            '2' => 1,
            '3' => 2,
        };
        private char ConvertIndexToRowMove(int move) => move switch
        {
            0 => 'A',
            1 => 'B',
            2 => 'C'
        };
        private char ConvertIndexToColMove(int move) => (char)(move + 1);

    }

}
