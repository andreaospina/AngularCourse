using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudioJunior
{
    public class menu
    {
       const string menuI = "escoja el juego: \n1- piedra papel o tijera\n2- frio caliente\n3- triqui";

        public void menuInicial()
        {
            Console.WriteLine(menuI);
            var eleccion = int.TryParse(Console.ReadLine(), out var numero);

            if (eleccion && numero == 1)
            {
                var PiedraPapelTijera = new piedraPapelTijera();
                PiedraPapelTijera.iniciarJuego();
            }
            else if (eleccion && numero == 2)
            {
              var FrioCaliente = new frioCaliente();
                FrioCaliente.iniciarJuego();
            }
            else if (eleccion && numero == 3)
            {
                var Triqui = new triqui();
                Triqui.iniciarJuego();

            }else
            {
                Console.WriteLine("escriba un numero correcto");
                menuInicial();
            }

        }
        
    }
}
