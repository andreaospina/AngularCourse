// See https://aka.ms/new-console-template for more information
using JuegosDeConsola;
Console.WriteLine("Welcome to the console games!");
Console.WriteLine("Please type your name to be able to recognize you.");
var playerName = Console.ReadLine();


var opt = "";
do
{
    Console.WriteLine("");
    Console.WriteLine("Please choose one game, press:");
    Console.WriteLine("1. To play cold-hot");
    Console.WriteLine("2. To play rock-paper-scissors");
    Console.WriteLine("3. To play tic-tac-toe");
    Console.WriteLine("0. To exit the menu");
    Console.WriteLine("");
    opt = Console.ReadLine();
    switch (opt)
    {
        case "1":
            var chGame = new ColdHotGame();
            chGame.playerName = playerName;
            chGame.Start();
            Console.Clear();
            break;
        case "2":
            var rpsGame = new RockPaperScissorsGame();
            rpsGame.Start();
            Console.Clear();
            break;
        case "3":
            var ttt = new TicTacToe();
            ttt.Start(playerName);
            Console.Clear();
            break;
        case "0":
            Console.WriteLine("Thank you for playing with the console games!");
            break;
        default:
            Console.WriteLine("You chose an invalid option, please try again or type 0 to exit the game.");
            break;
    }

} while (opt != "0");


