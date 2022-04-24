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
        /// <returns></returns>
        public static List<string> SeleccionFecha(string SeleccionIdioma)
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

            return Mensajes;
        }

        /// <summary>
        /// Concatena la diferencia en años de la actualidad de una fecha
        /// </summary>
        /// <param name="DiferenciasAnnios"></param>
        /// <param name="DiferenciaDias"></param>
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
        /// <returns></returns>
        public static string ConcantenarDiferenciaEntreFechas(int DiferenciasAnnios, int DiferenciaDias, List<string> Mensajes)
        {
            string concatenado = Mensajes[2] + DiferenciasAnnios + Mensajes[3] + DiferenciaDias;
            return concatenado;
        }
    }
}
