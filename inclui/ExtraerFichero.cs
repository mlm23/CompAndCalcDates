using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace inclui.CompAndCalcDates
{
    public class ExtraerFichero
    {
        /// <summary>
        /// Función que extrae el contenido del fichero con su idioma a elegir
        /// </summary>
        /// <param name="NombreFichero"></param>
        /// <returns></returns>
        public static List<string> ExtraerContenidoFichero(string NombreFichero)
        {
            List<string> ContenidoFichero = new List<string>();
            try
            {
                StreamReader LeerFichero = new StreamReader(NombreFichero);
                while (!LeerFichero.EndOfStream)
                {
                    ContenidoFichero.Add(LeerFichero.ReadLine());
                }
                LeerFichero.Close();
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            return ContenidoFichero;
        }
    }
}
