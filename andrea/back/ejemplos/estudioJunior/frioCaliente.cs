using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudioJunior
{
    public class frioCaliente
    {
        const int cantidadIntetos = 10;
        string reglas = $"se tendran {cantidadIntetos} intentos para descubrir el numero correcto\nel numero estara en un rango del 1 al 100\n" +
            "en cada intento se daran las siguientes indicaciones:\n" +
            "1- si esta en un rango mayor a 10 numeros se dira que esta frio\n" +
            "2- si esta en un rango menor a 10 numeros se dira que esta caliente";
        public void iniciarJuego()
        {
            Console.WriteLine(reglas);
            var numeroGanador = new Random().Next(1, 100);
            var numeroxdebajo = numeroGanador - 10;
            var numeroxensima = numeroGanador + 10;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("escriba numero");
                var eleccion = int.TryParse(Console.ReadLine(), out var numero);
                if (!eleccion || numero < 0 && numero > 100)
                {
                    Console.WriteLine("escriba un numero correcto");
                }
                else if (numero == numeroGanador)
                {
                    Console.WriteLine("Ganaste");
                    break;
                    menu();
                }
                else if (numero < numeroxdebajo || numero > numeroxensima)
                {
                    Console.WriteLine("frio");
                }
                else if (numero > numeroxdebajo || numero < numeroxensima)
                {
                    Console.WriteLine("caliente");
                }

                if (i == cantidadIntetos-1)
                {
                    Console.WriteLine("perdiste");
                    menu();
                }
               
            }
         
        }

        public void menu()
        {
            Console.WriteLine("Desea seguir jugando? escriba si o no");
            var resultado = Console.ReadLine().ToLower();
            if (resultado == "si")
            {
                iniciarJuego();

            }
            else if (resultado == "no")
            {
                var Menu = new menu();
                Menu.menuInicial();
            }
        }
    }
}
