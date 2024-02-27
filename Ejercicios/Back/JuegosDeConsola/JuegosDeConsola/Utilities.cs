using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegosDeConsola
{
    internal class Utilities
    {
        public void PrintGameWelcome(string playerName, string gameName, string rules, ConsoleColor color = ConsoleColor.Yellow)
        {
            Console.Clear();
            Console.ResetColor();
            Console.WriteLine($"Hello {playerName}");
            Console.Write($"Welcome to the ");
            Console.ForegroundColor = color;
            Console.Write(gameName);
            Console.ResetColor();
            Console.Write(" game !!");
            Console.WriteLine(rules);
        }

        public void PrintWinner(string playerName)
        {
            Console.ResetColor();
            Console.WriteLine($"¡¡¡ Congratulations {playerName} !!!");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("     YOU WON     ");
            Console.ResetColor();
        }

        public void PrintLoser(string playerName)
        {
            Console.ResetColor();
            Console.WriteLine($"Sorry for you {playerName}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("     YOU LOST THE GAME.     ");
            Console.ResetColor();
        }

        public void PrintInColor(string text, ConsoleColor color = ConsoleColor.Red)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }
    }
}
