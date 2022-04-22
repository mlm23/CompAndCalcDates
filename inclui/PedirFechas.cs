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
        public static void PrimeraFecha()
        {
            Console.WriteLine(Mensajes[0]);
        }

        public static void SegundaFecha()
        {
            Console.WriteLine(Mensajes[1]);
        }

        public static void Continuar()
        {
            Console.WriteLine(Mensajes[2]);
            Console.ReadKey();
            Console.Clear();
        }
    }
}
