using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego2_op_funciones
{
    internal class Program
    {
        #region Definición - Dado
        static Random azar = new Random();
        static int dado;
        #endregion

        #region Definición - Jugadores
        static int posJugador1, posJugador2;
        static string nombreJ1, nombreJ2;
        #endregion

        #region Definición - Escaleras
        static int pieEscalera1, pieEscalera2, cabeceraEscalera1, cabeceraEscalera2;
        #endregion

        #region Definición - Fin de Juego
        static bool finJuego = false;
        #endregion

        #region Definición - Serpiente
        static int serpienteCola, serpienteCabeza;
        #endregion

        static void InicializarEscaleras()
        {
            #region Inicializar Posición - Escaleras
            pieEscalera1 = azar.Next(1, 100);
            pieEscalera2 = azar.Next(1, 100);
            cabeceraEscalera1 = azar.Next(pieEscalera1, 100);
            cabeceraEscalera2 = azar.Next(pieEscalera2, 100);
            #endregion

            #region Inicializar Posición - Serpiente
            serpienteCola = azar.Next(1, 100);
            serpienteCabeza = azar.Next(serpienteCola, 100);
            #endregion
        }

        static int DeterminarAvance(int posicionJugador)
        {
            dado = azar.Next(1, 6);
            posicionJugador += dado;

            if (serpienteCabeza == posicionJugador)
            {
                posicionJugador = serpienteCola;
            }
            if (pieEscalera1 == posicionJugador)
            {
                posicionJugador = cabeceraEscalera1;
            }
            if (pieEscalera2 == posicionJugador)
            {
                posicionJugador = cabeceraEscalera2;
            }

            return posicionJugador;
        }


        static void Main(string[] args)
        {
            #region Iniciar - Posición de Jugadores
            posJugador1 = 1;
            posJugador2 = 1;
            #endregion

            #region Pedir Nombres de Jugadores
            Console.WriteLine("Ingrese el nombre del Jugador 1:");
            nombreJ1 = Console.ReadLine();
            Console.WriteLine("Ingrese el nombre del Jugador 2:");
            nombreJ2 = Console.ReadLine();
            #endregion

            InicializarEscaleras();

            #region Iteración de Juego
            do
            {
                posJugador1 = DeterminarAvance(posJugador1);
                posJugador2 = DeterminarAvance(posJugador2);

                Console.WriteLine("Posición Jugador 1: " + posJugador1);
                Console.WriteLine("Posición Jugador 2:" + posJugador2);
                Console.WriteLine("-------------------- o --------------------");

                finJuego = (posJugador1 >= 100 || posJugador2 >= 100);
            } while (!finJuego);
            #endregion

            #region Comprueba el ganador y lo muestra
            if (posJugador1 >= 100 ^  posJugador2 >= 100)
            {
                if (posJugador1 >= 100) { Console.WriteLine("El ganador es: " + nombreJ1); }
                else { Console.WriteLine("El ganador es: " + nombreJ2); }
            }
            else
            {
                Console.WriteLine("No hubo ningún Ganador");
            }
            #endregion

            Console.ReadKey();
        }
    }
}
