using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace inclui.CompAndCalcDates
{
    class PedirFechas
    {
        private static string RutaEspannol = @"..\..\lenguajes\espannol\Program_ES.txt";
        private static string RutaIngles = @"..\..\lenguajes\espannol\Program_EN.txt";
        private static readonly List<string> Mensajes = ExtraerFichero.ExtraerContenidoFichero(RutaEspannol);
        /// <summary>
        /// Muestra la solicitud de la primera fecha
        /// </summary>
        public static void PrimeraFecha()
        {
            Console.WriteLine(Mensajes[0]);
        }
        /// <summary>
        /// Muestra la solicitud de la segunda fecha
        /// </summary>
        public static void SegundaFecha()
        {
            Console.WriteLine(Mensajes[1]);
        }
        /// <summary>
        /// Espera la continuación del ususario por teclado
        /// </summary>
        public static void Continuar()
        {
            Console.WriteLine(Mensajes[2]);
            Console.ReadKey();
            Console.Clear();
        }
    }
}
