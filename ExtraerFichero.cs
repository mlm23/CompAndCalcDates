using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CompAndCalcDates
{
    class ExtraerFichero
    {

        public static List<string> ExtraerFicheroEspannol(string NombreFichero)
        {

            List<string> ListaEspañol = new List<string>();
            try
            {
                StreamReader LeerFichero = new StreamReader(NombreFichero);
                while(!LeerFichero.EndOfStream)
                {
                    ListaEspañol.Add(LeerFichero.ReadLine());
                }

                LeerFichero.Close();
            }
            catch(Exception)
            {
                Console.WriteLine("Se ha producido un error a la hora de leer el fichero");
            }

            return ListaEspañol;
        }
    }
}
