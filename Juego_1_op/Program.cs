using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego_1_op
{
    internal class Program
    {
        static Random azar = new Random();
        static void Main(string[] args)
        {

            int dado;
            bool finJuego = false;

            int posJugador1 = 0;
            int posJugador2 = 0;


            Console.WriteLine("Escriba el nombre del Jugador 1 y 2");
            string nombreJ1 = Console.ReadLine();
            string nombreJ2 = Console.ReadLine();


            int pieEscalera1 = azar.Next(1, 100);
            int cabeceraEscalera1 = azar.Next(pieEscalera1, 100);

            int pieEscalera2 = azar.Next(1, 100);
            int cabeceraEscalera2 = azar.Next(pieEscalera2, 100);

            int serpienteCola = azar.Next(1, 100);
            int serpienteCabeza = azar.Next(serpienteCola, 100);

            do
            {

                dado = azar.Next(1, 6);
                posJugador1 += dado;

                if (posJugador1 == serpienteCabeza) { posJugador1 = serpienteCola; }
                if (posJugador1 == pieEscalera1) { posJugador1 = cabeceraEscalera1; }
                if (posJugador1 == pieEscalera2) { posJugador1 = cabeceraEscalera2; }

                dado = azar.Next(1, 6);
                posJugador2 += dado;
                if (posJugador2 == serpienteCabeza) { posJugador2 = serpienteCola; }
                if (posJugador2 == pieEscalera1) { posJugador2 = cabeceraEscalera1; }
                if (posJugador2 == pieEscalera2) { posJugador2 = cabeceraEscalera2; }

                Console.WriteLine("Posición Jugador 1: " + posJugador1);
                Console.WriteLine("Posición Jugador 2:" + posJugador2);
                Console.WriteLine("-------------------- o --------------------");

                finJuego = posJugador2 >= 100 ^ posJugador2 >= 100;
            } while (!finJuego);

            if (posJugador1 == 100 ^ posJugador2 == 100)
            {
                if (posJugador1 == 100) { Console.WriteLine("El ganador es " + nombreJ1); }
                else { Console.WriteLine("El ganador es " + nombreJ2); }
            }
            else
            {
                Console.WriteLine("Ningún jugador ganó");
            }
            Console.ReadKey();


        }
    }
}
