using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace innui.CompAndCalcDates
{
    public class Funciones
    {
        

        /// <summary>
        /// Se encarga de recoger cada dato que va introduciendo por consola y a su vez la va agregando en lista
        /// </summary>
        /// <returns> Una lista con año, mes y día </returns>
        public static List<int> RellenarArrays(List<string> Mensajes)
        {
            List<int> Fecha = new List<int>();
            int anno = inclui.CompAndCalcDates.MostradoFunciones.SolicitarAnno(Mensajes);
            Fecha.Add(anno);
            int mes = inclui.CompAndCalcDates.MostradoFunciones.SolicitarMes(Mensajes);
            Fecha.Add(mes);
            bool bisiesto = Funciones.Comprobarbisiesto(anno);
            int dia = Funciones.ComprobacionDias(anno, mes, bisiesto, Mensajes);
            Fecha.Add(dia);
            Console.Clear();
            return Fecha;
        }
              
        /// <summary>
        /// Verificar si el año es bisiesto o no
        /// </summary>
        /// <param name="anno"></param>
        /// <returns> un valor si es true es bisiesto, si es false no es bisiesto</returns>
        public static bool Comprobarbisiesto(int anno)
        {
            bool comprobacion = false;
            if (DateTime.IsLeapYear(anno))
            {
                comprobacion = true;
            }
            return comprobacion;
        }
        /// <summary>
        /// Valida que el dato día este introducido correctamente respetando los requisitos
        /// </summary>
        /// <param name="anno"></param>
        /// <param name="mes"></param>
        /// <param name="bisiesto"></param>
        /// <returns> el valor del dia de la fecha </returns>
        public static int ComprobacionDias(int anno, int mes, bool bisiesto, List<string> Mensajes)
        {
            int dia = 0;
            bool Correcto = false;
            bool Error = true;
            do
            {
                //llamamos a la función que se introduce el número del dia 
                dia = inclui.CompAndCalcDates.MostradoFunciones.IntroducirDia(mes, anno, dia, Mensajes);
                //En el caso que el mes sea febrero
                if (mes == 2)
                { 
                    //LLamamos a la funcion que chequea el dia esté entre los limites establecidos
                    inclui.CompAndCalcDates.MostradoFunciones.DiaFebrero(bisiesto, dia, ref Error, Mensajes);
                    //comprobamos que no se haya producido un error y si no hay error salimos del bucle
                    if (!Error)
                    {
                        Correcto = true;
                    }
                }
                else
                {
                    //vemos si el mes es par o impar 
                    if (mes % 2 != 0)
                    {
                        //LLamamos a la funcion para verificar que el valor de dia esté entre los limites establecidos (max 31)
                        inclui.CompAndCalcDates.MostradoFunciones.MesImpar(ref Error, dia, Mensajes);
                        //comprobamos que no se haya producido un error y si no hay error salimos del bucle
                        if (!Error)
                        {
                            Correcto = true;
                        }
                    }
                    else
                    {
                        //LLamamos a la funcion para verificar que el valor de dia esté entre los limites establecidos (max 30)
                        inclui.CompAndCalcDates.MostradoFunciones.MesPar(ref Error, dia, Mensajes);
                        //comprobamos que no se haya producido un error y si no hay error salimos del bucle
                        if (!Error)
                        {
                            Correcto = true;
                        }
                    }
                }


            } while (!Correcto);
            return dia;
        }
        
        /// <summary>
        /// Se encarga de hallar la fecha actual para luego hacer los cálculos, se recoge la información y se introduce en un  lista
        /// </summary>
        /// <returns> La lista de la fecha actual </returns>
        public static List<int> ObtenerFechaActual()
        {
            List<int> Fecha = new List<int>();
            //ponemos el formato que nos interesa para hacer los cálculos más sencillos
            string Date = DateTime.Now.ToString("yyyy-MM-dd");
            //dividimos por guión y lo ponemos en un array con el objetivo de sacar cada campo y luego añadirlo en la lista en su order correspondiente
            string[] dividir = Date.Split('-');
            foreach (string paso in dividir)
            {
                Int32.TryParse(paso, out int numero);
                Fecha.Add(numero);
            }
            return Fecha;
        }
    }
}
