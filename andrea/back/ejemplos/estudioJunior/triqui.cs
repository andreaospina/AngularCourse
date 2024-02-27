using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudioJunior
{
    public class triqui
    {
        string espacio = "--- --- ---";
        string[,] eleccion = new string[3, 3];
        string forma = "   1   2   3 \n" +
                        "1    |   |   \n" +
                        "  --- --- ---\n" +
                        "2    |   |   \n" +
                        "  --- --- ---\n" +
                        "3    |   |   \n";
        int[] posiciones = new int[3] {0,1,2};
        bool esMaquina = true;
        bool eligio = false;
        public void iniciarJuego()
        {
            elegirMenu();

            for (int i = 0; i < 5; i++)
            {
                EleccionJuego(1, "X");
                if (i >= 2)
                {
                  var ganador1 =  evaluarGanador("X");
                    if (ganador1)
                    {
                        break;
                    }
                }

                if (i == 4)
                {
                    Console.WriteLine("no hay ningun ganador aun");
                    elegirMenuFinal();
                    break;
                }


                if (esMaquina)
                {
                    if (i == 0)
                    {
                        elegirJuagadaMaquina();
                    }
                    else
                    {
                        elegirJugadaMaquina();
                        if (!eligio) 
                        {
                            elegirJugadaAleatoriaMaquina();
                        } 
                    }
                }
                else
                {
                    EleccionJuego(2, "O");
                }
               

                if (i > 2)
                {
                    var ganador2 = evaluarGanador("O");
                    if (ganador2)
                    {
                        break;
                    }
                }
            }

        }

        private bool veficarPosicion(int fila, int columna)
        {
            var estaVacio = eleccion[fila, columna] == null;
            return estaVacio;
        }


        private void EleccionJuego(int jugador, string distintivo)
        {
            int fila = -1;
            int columna = -1;
            bool estaVacio = false;

            //if (esMaquina == true)
            //{
            //    var eligio = elegirJuagadaMaquina();
            //    if (!eligio)
            //    {
            //        fila = elegirJugadaAleatoriaMaquina();
            //        columna = elegirJugadaAleatoriaMaquina();
            //        estaVacio = veficarPosicion(fila, columna);
                   
            //    }
                
            //}
            //else
            //{
                 fila = elegirJugada(jugador, "fila", distintivo);
                 columna = elegirJugada(jugador, "columna", distintivo);
                estaVacio = veficarPosicion(fila, columna);
            //}

            if (estaVacio)
            {
                eleccion[fila, columna] = distintivo;
                //if(esMaquina) Console.WriteLine($"la eleccion de la maquina fue fila: {fila + 1} columna {columna + 1}");
                imprimirJuego();
            }
            else
            {
               Console.WriteLine("posicion ocupada escoja nuevamente");
                EleccionJuego(jugador, distintivo);
            };
        }
        private void imprimirJuego()
        {

            for (int f = 0; f < eleccion.GetLength(0); f++)
            {
                string cadena = "";

                for (int c = 0; c < eleccion.GetLength(1); c++)
                {
                    if (c == 0 || c == 1)
                    {
                        if (eleccion[f, c] == null)
                        {
                            cadena += "   |";
                        }
                        else
                        {
                            cadena += $" {eleccion[f, c]} |";
                        }
                    }
                    else
                    {
                        if (eleccion[f, c] == null)
                        {
                            cadena += "   ";
                        }
                        else
                        {
                                cadena += $" {eleccion[f,c]} ";
                        }
                    }
                }

                Console.WriteLine(cadena);
                if (f != 2)
                {
                    Console.WriteLine(espacio);
                }
            }
        }

        public void elegirJugadaMaquina()
        {
             eligio = false;

            for (int f = 0; f < eleccion.GetLength(0); f++)
            {
                if(eligio)break;

                for (int c = 0; c < eleccion.GetLength(1); c++)
                {
                    if (eleccion[f, 1] == null)
                    {
                        if (eleccion[f, 0] == "X" && eleccion[f, 2] == "X")
                        {
                            var estaVacio = veficarPosicion(f, 1);
                            if (estaVacio)
                            {
                                eleccion[f, 1] = "O";
                                eligio = true;
                                Console.WriteLine($"la eleccion de la maquina fue fila: {f + 1} columna {2}");
                                break;
                            }
                       
                        }
                        //else if (eleccion[0, 0] == "X" && eleccion[2, 2] == "X")
                        //{
                        //    eleccion[1, 1] = "O";
                        //    eligio = true;
                        //    break;
                        //} else if (eleccion[0, 2] == "X" && eleccion[2, 0] == "X")
                        //{
                        //    eleccion[1, 1] = "O";
                        //    eligio = true;
                        //    break;
                       // } 
                    else
                        {
                            break;
                        }
                    }
                    else if (eleccion[f, 1] == "X")
                    {
                        if (eleccion[f, 0] == "X")
                        {
                            var estaVacio = veficarPosicion(f, 2);
                            if (estaVacio)
                            {
                                eleccion[f, 2] = "O";
                                eligio = true;
                                Console.WriteLine($"la eleccion de la maquina fue fila: {f + 1} columna {3}");
                                break;
                            }
                        }
                        else if (eleccion[f, 2] == "X")
                        {
                            var estaVacio = veficarPosicion(f, 0);
                            if (estaVacio)
                            {
                                eleccion[f, 0] = "O";
                                eligio = true;
                                Console.WriteLine($"la eleccion de la maquina fue fila: {f + 1} columna {1}");
                                break;
                            }
                        }

                        if (eleccion[1, 1] == "X")
                        {
                            if (eleccion[0, 2] == "X")
                            {
                                var estaVacio = veficarPosicion(0, 1);
                                if (estaVacio)
                                {
                                    eleccion[0, 1] = "O";
                                    eligio = true;
                                    Console.WriteLine($"la eleccion de la maquina fue fila: {1} columna {2}");
                                    break;
                                }
                            }
                            else if (eleccion[2, 0] == "X")
                            {
                                var estaVacio = veficarPosicion(0, 2);
                                if (estaVacio)
                                {
                                    eleccion[0, 2] = "O";
                                    eligio = true;
                                    Console.WriteLine($"la eleccion de la maquina fue fila: {1} columna {3}");
                                    break;
                                }
                            }
                            else if (eleccion[0, 0] == "X")
                            {
                                var estaVacio = veficarPosicion(2, 2);
                                if (estaVacio)
                                {
                                    eleccion[2, 2] = "O";
                                    eligio = true;
                                    Console.WriteLine($"la eleccion de la maquina fue fila: {3} columna {3}");
                                    break;
                                }
                            }
                            else if (eleccion[2, 2] == "X")
                            {
                                var estaVacio = veficarPosicion(0, 0);
                                if (estaVacio)
                                {
                                    eleccion[0, 0] = "O";
                                    eligio = true;
                                    Console.WriteLine($"la eleccion de la maquina fue fila: {1} columna {1}");
                                    break;
                                }
                            }
                        }

                    }
                    else if (eleccion[1, 0] == "X")
                    {
                        if (eleccion[0, 0] == "X")
                        {
                            var estaVacio = veficarPosicion(2, 0);
                            if (estaVacio)
                            {
                                eleccion[2, 0] = "O";
                                eligio = true;
                                Console.WriteLine($"la eleccion de la maquina fue fila: {3} columna {1}");
                                break;
                            }
                        }
                        else
                        {
                            var estaVacio = veficarPosicion(0, 0);
                            if (estaVacio)
                            {
                                eleccion[0, 0] = "O";
                                eligio = true;
                                Console.WriteLine($"la eleccion de la maquina fue fila: {1} columna {1}");
                                break;
                            }
                        }
                     
                    }
                    else if (eleccion[1, 2] == "X")
                    {
                        if (eleccion[0, 2] == "X")
                        {
                            var estaVacio = veficarPosicion(2, 2);
                            if (estaVacio)
                            {
                                eleccion[2, 2] = "O";
                                eligio = true;
                                Console.WriteLine($"la eleccion de la maquina fue fila: {3} columna {3}");
                                break;
                            }
                        }
                        else
                        {
                            var estaVacio = veficarPosicion(0, 2);
                            if (estaVacio)
                            {
                                eleccion[0, 2] = "O";
                                eligio = true;
                                Console.WriteLine($"la eleccion de la maquina fue fila: {1} columna {3}");
                                break;
                            }
                        }
                    }


                }
            }
            if (!eligio)
            {
                elegirJugadaAleatoriaMaquina();
            }
            imprimirJuego();

        }
        //"   0   1   2 \n" +
        //"0    |   |   \n" +
        //"  --- --- ---\n" +
        //"1    |   |   \n" +
        //"  --- --- ---\n" +
        //"2    |   |   \n";
        private bool evaluarGanador(string letra)
        {
            bool ganador = false;

            if (eleccion[0, 0] == letra && eleccion[0, 1] == letra && eleccion[0, 2] == letra)
            {
                var jugador = letra == "X" ? 1 : 2;
                Console.WriteLine($"el jugador {jugador} es el ganador");
                ganador = true;
            }
            else if (eleccion[1, 0] == letra && eleccion[1, 1] == letra && eleccion[1, 2] == letra)
            {
                var jugador = letra == "X" ? 1 : 2;
                Console.WriteLine($"el jugador {jugador} es el ganador");
                ganador = true;
            }
            else if (eleccion[2, 0] == letra && eleccion[2, 1] == letra && eleccion[2, 2] == letra)
            {
                var jugador = letra == "X" ? 1 : 2;
                Console.WriteLine($"el jugador {jugador} es el ganador");
                ganador = true;
            }
            else if (eleccion[0, 0] == letra && eleccion[1, 0] == letra && eleccion[2, 0] == letra)
            {
                var jugador = letra == "X" ? 1 : 2;
                Console.WriteLine($"el jugador {jugador} es el ganador");
                ganador = true;
            }
            else if (eleccion[0, 1] == letra && eleccion[1, 1] == letra && eleccion[2, 1] == letra)
            {
                var jugador = letra == "X" ? 1 : 2;
                Console.WriteLine($"el jugador {jugador} es el ganador");
                ganador = true;
            }
            else if (eleccion[0, 2] == letra && eleccion[1, 2] == letra && eleccion[2, 2] == letra)
            {
                var jugador = letra == "X" ? 1 : 2;
                Console.WriteLine($"el jugador {jugador} es el ganador");
                ganador = true;
            }
            else if (eleccion[0, 0] == letra && eleccion[1, 1] == letra && eleccion[2, 2] == letra)
            {
                var jugador = letra == "X" ? 1 : 2;
                Console.WriteLine($"el jugador {jugador} es el ganador");
                ganador = true;
            }
            else if (eleccion[0, 2] == letra && eleccion[1, 1] == letra && eleccion[2, 0] == letra)
            {
                var jugador = letra == "X" ? 1 : 2;
                Console.WriteLine($"el jugador {jugador} es el ganador");
                ganador = true;
            }

            if (ganador)
            {
                elegirMenuFinal();
            }

            return ganador;
        }

        private int elegirJugada(int jugador, string posicion, string eleccion)
        {
            Console.WriteLine($"jugador {jugador} escriba el numero de la {posicion} en donde desea poner la {eleccion}");
            var esNum = int.TryParse(Console.ReadLine(), out var numeroFila);
            if (!esNum || numeroFila > 3 || numeroFila < 0)
            {
                Console.WriteLine("escriba un numero correcto");
                return elegirJugada(jugador, posicion, eleccion);

            }
            else
            {
                return numeroFila - 1;
            }
        }

        private void elegirMenuFinal()
        {
            Console.WriteLine("desea seguir jugando?\n1- si \n2- no");
            var respuesta = int.TryParse(Console.ReadLine(), out var number);
            if (respuesta && number == 2)
            {
                var menuP = new menu();
                menuP.menuInicial();
            }
            else if (respuesta && number == 1)
            {
                limpiar();
                iniciarJuego();
            }
            else
            {
                Console.WriteLine("escriba un numero correcto");
                elegirMenuFinal();
            }
        }

        private void limpiar()
        {
            for (int f = 0; f < eleccion.GetLength(0); f++)
            {
                for (int c = 0; c < eleccion.GetLength(1); c++)
                {
                    eleccion[f, c] = null;
                }
            }
            Console.Clear();
        }

        private void elegirJugadaAleatoriaMaquina()
        {

            var fila = new Random().Next(0, 3);
            var columna = new Random().Next(0, 3);
            var estaVacio = veficarPosicion(fila, columna);
            if (estaVacio)
            {
                eleccion[fila, columna] = "O";
            }
            else
            {
                elegirJugadaAleatoriaMaquina();
            }
        }

        private void elegirMenu()
        {
            esMaquina = false;
            string reglas = "1- el primer jugador que elija donde realizar la jugada tendra como distintivo" +
                "una X y el segundo jugador una O \n2- para elegir donde realizar la jugada de debe escribir el numero" +
                " de la fila y luego el numero de columna.\nesta es la guia para escoger: \n" +
                forma;
            string jugador = "Escriba:\n1- si desea jugar contra la maquina\n2- si desea jugar con otro jugador";
            Console.WriteLine(reglas);
            Console.WriteLine(jugador);
            var esNum = int.TryParse(Console.ReadLine(), out var numero);
            if (!esNum || numero <1 && numero > 2)
            {
                Console.WriteLine("escriba un numero correcto");
                elegirMenu();
            }
            else
            {
                    if(numero == 1) esMaquina = true;
            }
        }

        private void elegirJuagadaMaquina()
        {

            if (eleccion[1, 1] == null)
            {
                eleccion[1, 1] = "O";
                Console.WriteLine($"la eleccion de la maquina fue fila: {2} columna {2}");
            }
            else if (eleccion[0, 0] == null)
            {
                eleccion[0, 0] = "O";
                Console.WriteLine($"la eleccion de la maquina fue fila: {1} columna {1}");
            }
            else if (eleccion[0, 2] == null)
            {
                eleccion[0, 2] = "O";
                Console.WriteLine($"la eleccion de la maquina fue fila: {1} columna {3}");
            }
            else if (eleccion[2, 0] == null)
            {
                eleccion[2, 0] = "O";
                Console.WriteLine($"la eleccion de la maquina fue fila: {3} columna {1}");
            }
            else if (eleccion[2, 2] == null)
            {
                eleccion[2, 2] = "O";
                Console.WriteLine($"la eleccion de la maquina fue fila: {3} columna {3}");
            }

            imprimirJuego();
        }


    

    }
}
