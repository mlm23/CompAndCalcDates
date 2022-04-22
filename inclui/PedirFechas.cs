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
        private const string Ruta = @"..\..\lenguajes\espannol\Program_ES.txt";
        private static List<string> contenidoEspañol = ExtraerFichero.ExtraerContenidoFichero(Ruta);

        public static void PrimeraFecha()
        {
            Console.WriteLine(contenidoEspañol[0]);
        }

        public static void SegundaFecha()
        {
            Console.WriteLine(contenidoEspañol[1]);
        }

        public static void Continuar()
        {
            Console.WriteLine(contenidoEspañol[2]);
            Console.ReadKey();
            Console.Clear();
        }
    }
}
