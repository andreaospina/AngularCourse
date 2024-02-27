using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegosDeConsola.Models
{
    public class TicTacToeConfig
    {

        public string[] Diag1 = { "A1", "B2", "C3" };
        public string[] Diag2 = { "A3", "B2", "C1" };
        public string[] ValidRows = new string[] { "A", "B", "C" };
        public string[] ValidColumns = new string[] { "1", "2", "3" };
        public List<string> AvailableOptions;
        public string[,] GameTemplate;
        public string PlayerName = "Pedro";
        public string PlayerName2 = "";
        public Dictionary<char, int> Movements = new Dictionary<char, int>();
        public int RoundsCounter = 1;
        public bool RoundIsOver = false;
        public string Dificulty = "Easy";

        public TicTacToeConfig()
        {
            AvailableOptions = new() { "A1", "A2", "A3", "B1", "B2", "B3", "C1", "C2", "C3" };
            GameTemplate = new string[3, 3] {
                {" ", " ", " "},
                {" ", " ", " "},
                {" ", " ", " "}
            };
            Movements = new()
            {
                { 'A', 0 },
                { 'B', 0 },
                { 'C', 0 },
                { '1', 0 },
                { '2', 0 },
                { '3', 0 },
                { 'D', 0 },
                { 'E', 0 },
            };
            RoundIsOver = false;
            RoundsCounter = 1;
            PlayerName2 = "";
            Dificulty = "Easy";
        }


    }
}
