using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompAndCalcDates
{
    public class Funciones
    {
        /// <summary>
        /// esto sirve para presentar por pantalla las fechas que el usuario ha introducido
        /// </summary>
        /// <param name="Fecha1"> La primera Fecha que ha introducido </param>
        /// <param name="Fecha2"> La segunda Fecha que ha introducido </param>
        public static string MostrarFechas(List<int> Fecha)
        {
            string cadena = "la fecha es " + Fecha[0]+ "-" +Fecha[1] + "-" +Fecha[2];
            Console.WriteLine(cadena);
            return cadena;
        }
        /// <summary>
        /// su función es presentar por pantalla los cálculos realizados de las diferencias
        /// </summary>
        /// <param name="DiferenciaEntreFechas"> el valor de la diferencia entre las dos fechas introducidas por el usuario</param>
        /// <param name="DiferenciaHoyFecha1"> el valor de la diferencia entre la primera fecha y la fecha actual </param>
        /// <param name="DiferenciaHoyFecha2">  el valor de la diferencia entre la segunda fecha y la fecha actual </param>
        public static void MostrarEdades(string DiferenciaEntreFechas, string DiferenciaHoyFecha1, string DiferenciaHoyFecha2)
        {
            Console.WriteLine("A continuación visualizaremos la diferencia entre las dos fechas dadas: ");
            Console.WriteLine(DiferenciaEntreFechas);
            Console.WriteLine("\n ");
            Console.WriteLine("A continuación visualizaremos la diferencia entre la primera fecha y la fecha actualmente: ");
            Console.WriteLine(DiferenciaHoyFecha1);
            Console.WriteLine("\n ");
            Console.WriteLine("A continuación visualizaremos la diferencia entre la segunda fecha y la fecha actualmente: ");
            Console.WriteLine("\n ");
            Console.WriteLine(DiferenciaHoyFecha2);

        }
        /// <summary>
        /// Se encarga de recoger cada dato que va introduciendo por consola y a su vez la va agregando en lista
        /// </summary>
        /// <returns> Una lista con año, mes y día </returns>
        public static List<int> RellenarArrays()
        {
            List<int> Fecha = new List<int>();
            int anno = Funciones.SolicitarAnno();
            Fecha.Add(anno);
            int mes = Funciones.SolicitarMes();
            Fecha.Add(mes);
            bool bisiesto = Funciones.Comprobarbisiesto(anno);
            int dia = Funciones.ComprobacionDias(anno, mes, bisiesto);
            Fecha.Add(dia);
            return Fecha;
        }
        /// <summary>
        /// Solicitar un número para saber si la fecha está antes o después de Cristo
        /// </summary>
        /// <returns> El valor 0 o 1 que indica el Periodo </returns>
        public static int SolicitarPeriodo()
        {
            int periodo = 0;
            bool leido = false;
            //Un bucle que hasta que no se verifique bien la entrada de datos no salimos por eso el booleano
            do
            {
                Console.WriteLine(" Pulse 0 si el siguiente año es antes de Cristo o teclee 1 si es despúes de Cristo");
                if (!int.TryParse(Console.ReadLine(), out periodo))
                {
                    Console.WriteLine("Dato no válido el periodo debe ser un número entero");
                    Console.WriteLine("Presione una tecla para volver a intentarlo");
                    Console.ReadKey();
                }
                else
                {
                    //El periodo no puede ser negativo y el usuario vuelve a introducir el dato
                    if (periodo < 0)
                    {
                        Console.WriteLine("El periodo no puede ser negativo");
                        Console.WriteLine("Presione una tecla para volver a intentarlo");
                        Console.ReadKey();
                    }
                    else
                    {
                        //Si es 0 sería antes de Cristo y salimos del bucle con el booleano 
                        if (periodo == 0)
                        {
                            leido = true;
                        }
                        else
                        {
                            //Si es 1 es después de Cristo y salimos del bucle con el booleano 
                            if (periodo == 1)
                            {
                                leido = true;
                            }
                            else
                            {
                                Console.WriteLine("No ha introducido un 0 o 1");
                                Console.WriteLine("Presione una tecla para volver a intentarlo");
                                Console.ReadKey();
                            }

                        }

                    }
                }

            } while (!leido);

            return periodo;
        }
        /// <summary>
        /// Solicita el Año de la fecha 
        /// </summary>
        /// <returns> El valor del año de la fecha</returns>
        public static int SolicitarAnno()
        {
            int anno = 0;
            bool leido = false;
            //no salimos hasta que la entrada de datos esté correctamente
            do
            {
                Console.WriteLine("Introduza el año");
                if (!int.TryParse(Console.ReadLine(), out anno))
                {
                    Console.WriteLine("Dato no válido el año tiene que ser un número entero");
                    Console.WriteLine("Presione una tecla para volver a intentarlo");
                    Console.ReadKey();
                }
                else
                {
                    //el año debe ser positivo, no adminitimos en el programa datos negativos
                    if (anno > 0)
                    {
                        //el limite de fechas que acepta el windows respecto a la fecha actual
                        if (anno < 9999)
                        {
                            leido = true;
                        }
                        else
                        {
                            Console.WriteLine("Fuera de rango");
                            Console.WriteLine("Presione una tecla para volver a intentarlo");
                            Console.ReadKey();
                        }

                    }
                    else
                    {
                        Console.WriteLine("El año no puede ser negativo");
                        Console.WriteLine("Presione una tecla para volver a intentarlo");
                        Console.ReadKey();
                    }
                }

            } while (!leido);
            return anno;
        }
        /// <summary>
        /// Solicita el mes de la fecha
        /// </summary>
        /// <returns> El valor del mes</returns>
        public static int SolicitarMes()
        {
            int mes = 0;
            //creo un array en donde están los nombres de los meses, el objetivo es que el usuario introduzca el nombre del mes
            //y luego devolver con la posición del array que es lo que corresponde al número del mes

            string[] meses = {"enero","febrero","marzo",
                "abril","mayo","junio","julio","agosto",
                    "septiembre","octubre","noviembre","diciembre"};
            bool leido = false;
            do
            {
                Console.WriteLine("Introduzca el nombre del mes");
                string cadena = Console.ReadLine().Trim();
                if (cadena != "")
                {
                    bool recorrer = false;
                    int contador = 0;
                    //recorro el array meses
                    while (!recorrer)
                    {
                        if (contador >= meses.Length)
                        {
                            recorrer = true;
                            Console.WriteLine("Nombre del mes mal introducido");
                            Console.WriteLine("Presione una tecla para volver a intentarlo");
                            Console.ReadKey();
                        }
                        else
                        {
                            //El ToLower() es por si el usuario introduce algo en mayúscula y luego lo compara todo en minúscula con el array
                            if (cadena.ToLower() == meses[contador])
                            {
                                //el mes es la posicion en donde se haya el mes en el array
                                mes = contador + 1;
                                recorrer = true;
                                leido = true;
                            }
                        }
                        contador++;
                    }
                }
            } while (!leido);
            return mes;
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
        public static int ComprobacionDias(int anno, int mes, bool bisiesto)
        {
            int dia = 0;
            bool Correcto = false;
            bool Error = true;
            do
            {
                //llamamos a la función que se introduce el número del dia 
                dia = IntroducirDia(mes, anno, dia);
                //En el caso que el mes sea febrero
                if (mes == 2)
                { 
                    //LLamamos a la funcion que chequea el dia esté entre los limites establecidos
                    DiaFebrero(bisiesto, dia, ref Error);
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
                        MesImpar(ref Error, dia);
                        //comprobamos que no se haya producido un error y si no hay error salimos del bucle
                        if (!Error)
                        {
                            Correcto = true;
                        }
                    }
                    else
                    {
                        //LLamamos a la funcion para verificar que el valor de dia esté entre los limites establecidos (max 30)
                        MesPar(ref Error, dia);
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
        /// Se introduce por consola el numero del dia de la fecha
        /// </summary>
        /// <param name="mes"></param>
        /// <param name="anno"></param>
        /// <param name="dia"></param>
        /// <returns></returns>
        public static int IntroducirDia(int mes, int anno, int dia)
        {

            bool leido = false;
            do
            {
                Console.WriteLine("Introduzca el dia del {0} del mes {1}", anno, mes);
                if (!Int32.TryParse(Console.ReadLine(), out dia))
                {
                    Console.WriteLine("Dato no válido el dia tiene que ser un número entero");
                    Console.WriteLine("Presione una tecla para volver a intentarlo");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    //dia tiene que ser positivo, no se admite en el programa datos negativos
                    if (dia > 0)
                    {
                        leido = true;
                    }
                    else

                    {
                        Console.WriteLine("El dia tiene que ser positivo");
                        Console.WriteLine("Presione una tecla para volver a intentarlo");
                        Console.ReadKey();
                    }

                }

            } while (!leido);
            return dia;
        }
        /// <summary>
        /// Se encarga de verificar que dia esté entre los limites que son si es bisiesto 29 max y si no 28 max
        /// </summary>
        /// <param name="bisiesto"></param>
        /// <param name="dia"></param>
        /// <param name="Error"></param>
        public static void DiaFebrero(bool bisiesto, int dia, ref bool Error)
        {
           
            if (bisiesto)
            {
                if (dia <= 29)
                {
                    Error = false;
                }
                else
                {
                    Console.WriteLine("Dato no válido el dia tiene que ser menor al máximo o igual  que es 29");
                    Console.WriteLine("Presione una tecla para volver a intentarlo");
                    Console.ReadKey();
                    Console.Clear();
                    Error = true;
                }
            }
            else
            {
                if (dia <= 28)
                {
                    Error = false;
                }
                else
                {
                    Console.WriteLine("Dato no válido el dia tiene que ser menor al máximo o igual  que es 28");
                    Console.WriteLine("Presione una tecla para volver a intentarlo");
                    Console.ReadKey();
                    Console.Clear();
                    Error = true;
                }
            }
        }
        public static void MesImpar(ref bool Error, int dia)
        {
           //en los meses impares del año los días son hasta 31
            if (dia <= 31)
            {
                Error = false;
            }
            else
            {
                Console.WriteLine("Dato no válido el dia tiene que ser menor al máximo o igual que es 31");
                Console.WriteLine("Presione una tecla para volver a intentarlo");
                Console.ReadKey();
                Console.Clear();
                Error = true;
            }
        }
       
        public static void MesPar(ref bool Error, int dia)
        {
            //en los meses pares del año los días son hasta 30
            if (dia <= 30)
            {
                Error = false;
            }
            else
            {
                Console.WriteLine("Dato no válido el dia tiene que ser menor al máximo o igual que es 30");
                Console.WriteLine("Presione una tecla para volver a intentarlo");
                Console.ReadKey();
                Console.Clear();
                Error = true;
            }
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
