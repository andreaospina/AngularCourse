using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudioJunior
{
    public class piedraPapelTijera
    {
        //Dictionary<string, List<string>> historial = new Dictionary<string, List<string>>();

        Dictionary<int, string> eleccion = new Dictionary<int, string>();

        List<string> eleccionJugador1 = new List<string>();
        List<string> eleccionJugador2 = new List<string>();

        string menuPartida = "Escriba: \n 1 si desea elegir piedra \n 2 si desea elegir papel \n" +
            " 3 tijera";

        string mensajeError = "escriba un numero valido";

        int partidas = 0;

        public piedraPapelTijera()
        {
            eleccion[1] = "piedra";
            eleccion[2] = "papel";
            eleccion[3] = "tijera";

        }
        public void GagadorPartida(string jugador1, string jugador2)
        {

            partidas++;
            if (jugador1 == "tijera" && jugador2 == "papel" || jugador1 == "papel" && jugador2 == "piedra" ||
                jugador1 == "piedra" && jugador2 == "tijera")
            {
                eleccionJugador1.Add(jugador1);
                Console.WriteLine($"El ganador de la ronda {partidas}  es el jugador 1");

            }
            else if (jugador1 == jugador2)
            {
                partidas--;
                Console.WriteLine("hubo un empate");
            }
            else
            {
                eleccionJugador2.Add(jugador2);
                Console.WriteLine($"El ganador de la ronda {partidas}  es el jugador 2");
            }

            if (partidas > 3 || eleccionJugador1.Count == 2 || eleccionJugador2.Count == 2)
            {
                if (eleccionJugador1.Count > eleccionJugador2.Count)
                {
                    Console.WriteLine("el jugador 1 es el ganador");
                }
                else
                {
                    Console.WriteLine("el jugador 2 es el ganador");
                }

                finJuego();
            }
        }
        public void iniciarJuego()
        {
            string reglas = "se realizaran rondas de 3 partidas, si por lo menos un jugador gana dos de ellas es el ganador de dicho juego. \n" +
                "la pieda le gana a la tijera, la tijera le gana a el papel y el papael le gana a piedra";

            string menuJugador = "Escriba: \n 1 si quiere jugar contra la maquina \n 2 si van a participar dos jugadores \n" +
                " 3 volver a el menu inicial";

            Console.WriteLine(reglas);
            Console.WriteLine(menuJugador);
            var menu = int.TryParse(Console.ReadLine(), out var valor);

            switch (valor)
            {
                case 1:
                    while (partidas < 3)
                    {
                        var jugador1 = eleccionJugador(1);
                        var jugador2 = eleccionMaquina();
                        Console.WriteLine($"elejiste {jugador1}");
                        Console.WriteLine($"la maquina eligio {jugador2}");
                        GagadorPartida(jugador1, jugador2);
                    }
                    break;

                case 2:
                    while (partidas < 3)
                    {
                        var jugador1 = eleccionJugador(1);
                        var jugador2 = eleccionJugador(2);
                        GagadorPartida(jugador1, jugador2);
                    }
                    break;

                case 3:
                    var menuP = new menu();
                    menuP.menuInicial();
                    break;

                default:
                    Console.WriteLine(mensajeError);

                    break;
            }
        }
        public string eleccionMaquina()
        {
            var numero = new Random().Next(1, 3);
            return eleccion[numero];
        }

        public string eleccionJugador(int jugador)
        {
            Console.WriteLine($"jugador {jugador} {menuPartida}");
            var menuP = int.TryParse(Console.ReadLine(), out var valor);
            if (!menuP || valor > 3)
            {
                Console.WriteLine(mensajeError);
                return "";
            }
            else
            {
                return eleccion[valor];
            }
        }

        public void limpiar()
        {
            partidas = 0;
            eleccionJugador1.Clear();
            eleccionJugador2.Clear();
        }

        public void finJuego()
        {
            Console.WriteLine("Desea seguir jugando? escriba si o no");
            var resultado = Console.ReadLine();
            resultado = resultado.ToLower();
            if (resultado == "si")
            {
                //historial.Add("jugador1", eleccionJugador1);
                //historial.Add("jugador2", eleccionJugador2);
                limpiar();
                iniciarJuego();

            }
            else if (resultado == "no")
            {
                //    if (historial["jugador1"].Count > historial["jugador2"].Count)
                //    {
                //        Console.WriteLine("el ganador del juego es el jugador 1");
                //        mostrarListadoGanador(historial["jugador1"]);
                //    }
                //    else
                //    {
                //        Console.WriteLine("el ganador del juego es el jugador 2");
                //        mostrarListadoGanador(historial["jugador2"]);
                //    }

                limpiar();
                //historial.Clear();
                var Menu = new menu();
                Menu.menuInicial();
            }
            else
            {
                Console.WriteLine("valor ingresado incorrecto elija nuevamente");
                finJuego();
            }
        }

        private void mostrarListadoGanador(List<string> jugador)
        {
            Console.WriteLine($"gano {jugador.Count} partidas");
            Console.WriteLine($"con el siguiente resultado:");
            foreach (var item in jugador)
            {
                Console.WriteLine(item);
            }
        }
    }
}
