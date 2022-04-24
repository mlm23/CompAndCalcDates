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
        /// <summary>
        /// Con el idioma introducido por teclado se seleccionna la ruta del archivo
        /// </summary>
        /// <param name="SeleccionIdioma"></param>
        /// <returns></returns>
        public static List<string> SeleccionFecha(string SeleccionIdioma)
        {
            string RutaEspannol = @"..\..\lenguajes\espannol\Program_ES.txt";
            string RutaIngles = @"..\..\lenguajes\ingles\Program_EN.txt";
            string Ruta = "";

            switch (SeleccionIdioma)
            {
                case "Español": Ruta = RutaEspannol; break; //Español
                case "Ingles": Ruta = RutaIngles; break; //Ingles
            }

            List<string> Mensajes = ExtraerFichero.ExtraerContenidoFichero(Ruta);

            return Mensajes;
        }
        /// <summary>
        /// Muestra la solicitud de la primera fecha
        /// </summary>
        public static void PrimeraFecha(List<string> Mensajes)
        {
            Console.WriteLine(Mensajes[0]);
        }
        /// <summary>
        /// Muestra la solicitud de la segunda fecha
        /// </summary>
        public static void SegundaFecha(List<string> Mensajes)
        {
            Console.WriteLine(Mensajes[1]);
        }
        /// <summary>
        /// Espera la continuación del ususario por teclado
        /// </summary>
        public static void Continuar(List<string> Mensajes)
        {
            Console.WriteLine(Mensajes[2]);
            Console.ReadKey();
            Console.Clear();
        }
    }
}
