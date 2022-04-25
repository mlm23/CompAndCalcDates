using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inclui.CompAndCalcDates
{
    class VariablesCalculos
    {

        /// <summary>
        /// Con el idioma introducido por teclado se seleccionna la ruta del archivo 
        /// </summary>
        /// <param name="SeleccionIdioma"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public static List<string> SeleccionFecha(string SeleccionIdioma,ref bool error)
        {
            string RutaEspannol = @"..\..\lenguajes\espannol\Calculos_ES.txt";
            string RutaIngles = @"..\..\lenguajes\ingles\Calculos_EN.txt";
            string Ruta = "";

            switch (SeleccionIdioma)
            {
                case "Español": Ruta = RutaEspannol; break; //Español
                case "Ingles": Ruta = RutaIngles; break; //Ingles
            }

            List<string> Mensajes = ExtraerFichero.ExtraerContenidoFichero(Ruta);
            if (Mensajes.Count() != 4)
            {
                error = true;
                switch (SeleccionIdioma)
                {
                    case "Español": Console.WriteLine("Error, el archivo Calculos_ES.txt no es válido\nFin del programa"); break; //Español
                    case "Ingles": Console.WriteLine("Error, Calculos_EN.txt file is invalid.\nEnd of program"); break; //Ingles
                }
            }
            return Mensajes;
        }

        /// <summary>
        /// Concatena la diferencia en años de la actualidad de una fecha
        /// </summary>
        /// <param name="DiferenciasAnnios"></param>
        /// <param name="DiferenciaDias"></param>
        /// <param name="Mensajes"></param>
        /// <returns></returns>
        public static string ConcatenarDiferenciaEntreHoy(int DiferenciasAnnios,int DiferenciaDias, List<string> Mensajes)
        {
            string concatenado = Mensajes[0] + DiferenciasAnnios + Mensajes[1] + DiferenciaDias;
            return concatenado;
        }
        /// <summary>
        /// Concatenia la diferencia de edades entre dos fechas
        /// </summary>
        /// <param name="DiferenciasAnnios"></param>
        /// <param name="DiferenciaDias"></param>
        /// <param name="Mensajes"></param>
        /// <returns></returns>
        public static string ConcantenarDiferenciaEntreFechas(int DiferenciasAnnios, int DiferenciaDias, List<string> Mensajes)
        {
            string concatenado = Mensajes[2] + DiferenciasAnnios + Mensajes[3] + DiferenciaDias;
            return concatenado;
        }
    }
}
