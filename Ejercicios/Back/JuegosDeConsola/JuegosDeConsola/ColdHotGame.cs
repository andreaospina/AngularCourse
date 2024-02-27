using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegosDeConsola
{
    internal class ColdHotGame
    {
        private Utilities utilities = new Utilities();
        private const int MAX_RETRIES = 5;
        private const string GAME_NAME = "Cold-Hot";
        private const string GAME_RULES = @"""
            You need to guess the random number, you should type a number between 1 and 100
            and i will be telling you if you are:
             * SUPER COLD (when you are very far from the real number)
             * COLD (when you are very far from the real number)
             * HOT (when you are near from the real number)
             * SUPER HOT (when you are very near from the real number)
            You only have 5 times to try.
        """;
        
        public string playerName = "";
        public void Start()
        {
            utilities.PrintGameWelcome(playerName, GAME_NAME, GAME_RULES);
            var playAgain = "";
            do
            {
                Play();
                Console.WriteLine("Do you want to play again? Y/N");
                playAgain = Console.ReadLine();

            } while (playAgain.ToLower() == "y");
        }

        private void Play()
        {
            var randomNumber = new Random().Next(1, 100);
            var won = false;
            var countRetries = 1;
            do
            {
                Console.WriteLine("");
                Console.WriteLine("Please type your guess:");
                var guess = Console.ReadLine();
                var validNumber = int.TryParse(guess, out var number);
                if (validNumber && number > 1 && number < 100)
                {
                    var distance = CalculateDistance(randomNumber, number);
                    if (distance == 0)
                    {
                        won = true;
                        break;
                    }
                    else
                    {
                        var distanceDesc = GetDistanceDescription(distance);
                        Console.WriteLine("You are " + distanceDesc);
                        Console.WriteLine($"You only have {MAX_RETRIES - countRetries} more times to try");
                        countRetries++;
                    }
                }
                else
                {
                    Console.WriteLine("You should type a number between 1 and 1000, please try again.");
                }


            } while (countRetries <= MAX_RETRIES);

            if (won)
            {
                utilities.PrintWinner(playerName);
            }
            else
            {
                utilities.PrintLoser(playerName);
                Console.WriteLine($"The number was {randomNumber}");
            }
        }
        private int CalculateDistance(int realNumber, int guessedNumber)
        {
            return Math.Abs(realNumber - guessedNumber);
        }

        private string GetDistanceDescription(int distance)
        {
            if (distance > 50)
            {
                return "SUPER COLD";
            }
            else if (distance > 10)
            {
                return "COLD";
            }
            else if (distance > 5)
            {
                return "HOT";
            }
            else
            {
                return "SUPER HOT";
            }
        }
    }
}
