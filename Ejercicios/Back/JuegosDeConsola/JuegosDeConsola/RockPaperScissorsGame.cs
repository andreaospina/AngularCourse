using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegosDeConsola
{
    internal class RockPaperScissorsGame
    {
        private Utilities utilities = new Utilities();
        private const int MAX_RETRIES = 5;
        private const string GAME_NAME = "Rock-Paper-Scissors";
        private const string GAME_RULES = @"""
            You need to play agains another player, in this case ME.
            You have 3 options to choose, ROCK, PAPER or SCISSORS. 
            After you choose an option i will choose one too and then we can see who wins. 
                * The Rock wins over the scissors
                * The scissors wins over the paper
                * The paper wins over the rock.
            The one who wins 2 out of 3 wins the game. 
        """;
        private string[] options = new string[] { "R", "P", "S" };
        public string playerName = "";
        private int userWins = 0;
        private int machineWins = 0;
        private Dictionary<string, int> history = new Dictionary<string, int>();

        public void Start()
        {
            utilities.PrintGameWelcome(playerName, GAME_NAME, GAME_RULES);
            var playAgain = "";
            do
            {
                CleanGame();
                Play();
                Console.WriteLine("Do you want to play again? Y/N");
                playAgain = Console.ReadLine();

            } while (playAgain.ToLower() == "y");
            PrintHistory();

        }
        private void PrintHistory()
        {
            Console.WriteLine($"You won {history["Jugador"]} games, and you lose {history["Maquina"]} games");   
        }
        private void Play()
        {
            for (int i = 1; i <= 3; i++)
            {
                var result = PlayRound(i); // False when it is a draw
                if (result == false)
                {
                    i--;
                    continue;
                }
                PrintScore();
                if (userWins >= 2)
                {
                    history["Jugador"]++;
                    utilities.PrintWinner(playerName);
                    break;
                }
                else if (machineWins >= 2)
                {
                    history["Maquina"]++;
                    utilities.PrintLoser(playerName);
                    break;

                }
            }
        }

        private bool PlayRound(int roundNumber)
        {
            Console.WriteLine($"Round number {roundNumber}");
            var userOption = GetUserOption();
            var machineOption = GetMachineOption();
            ShowChoses(userOption, machineOption);
            if (userOption == "R")
            {
                if (machineOption == "R")
                {
                    Console.WriteLine("Draw... Let's try again.");
                    return false;
                }
                else if (machineOption == "P")
                {
                    Console.WriteLine("I win this one.");
                    machineWins++;
                    return true;
                }
                else // The else will always be the "S"
                {
                    Console.WriteLine("You win this one.");
                    userWins++;
                    return true;
                }
            }
            else if (userOption == "P")
            {
                if (machineOption == "R")
                {
                    Console.WriteLine("You win this one.");
                    userWins++;
                    return true;
                }
                else if (machineOption == "P")
                {
                    Console.WriteLine("Draw... Try again.");
                    return false;
                }
                else
                {
                    Console.WriteLine("I win this one.");
                    machineWins++;
                    return true;
                }
            }
            else
            {
                if (machineOption == "R")
                {
                    Console.WriteLine("I win this one.");
                    machineWins++;
                    return true;
                }
                else if (machineOption == "P")
                {
                    Console.WriteLine("You win this one.");
                    userWins++;
                    return true;
                }
                else
                {
                    Console.WriteLine("Draw... Try again.");
                    return false;
                }
            }
        }

        private void PrintScore()
        {
            Console.WriteLine($"You have {userWins} of 3 wins");
            Console.WriteLine($"I have {machineWins} of 3 wins");
        }

        private string GetUserOption()
        {
            var userOption = "";
            do
            {
                Console.WriteLine("Please choose between R: for Rock, P: for paper and S: for scissors");
                userOption = Console.ReadLine();
                userOption = userOption?.ToUpper() ?? "";
                userOption = userOption == null ? "" : userOption.ToUpper(); // Same as before but with ternary operator

            } while (!options.Contains(userOption));
            return userOption;
        }

        private string GetMachineOption()
        {
            var machineOptionIndex = new Random().Next(0, 2);
            return options[machineOptionIndex];
        }

        private void ShowChoses(string userOption, string machineOption)
        {
            var userDesc = TranslateChosesToDescriptions(userOption);
            var machineDesc = TranslateChosesToDescriptions(machineOption);

            Console.WriteLine($"{userDesc} over {machineDesc}");
        }

        private string TranslateChosesToDescriptions(string option)
        {
            var desc = "";
            if (option == "R")
            {
                desc = "Rock";
            }
            else if (option == "P")
            {
                desc = "Paper";
            }
            else
            {
                desc = "Scissors";
            }
            return desc;
        }
        private void CleanGame()
        {
            userWins = 0;
            machineWins = 0;
        }
    }
}
