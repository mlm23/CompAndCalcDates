﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace inclui.CompAndCalcDates
{
    class MostradoFunciones
    {

        /// <summary>
        /// Con el idioma introducido por teclado se seleccionna la ruta del archivo
        /// </summary>
        /// <param name="SeleccionIdioma"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public static List<string> SeleccionFecha(string SeleccionIdioma,ref bool error)
        {
            string RutaEspannol = @"..\..\lenguajes\espannol\Funciones_ES.txt";
            string RutaIngles = @"..\..\lenguajes\ingles\Funciones_EN.txt";
            string Ruta = "";

            switch (SeleccionIdioma)
            {
                case "Español": Ruta = RutaEspannol; break; //Español
                case "Ingles": Ruta = RutaIngles; break; //Ingles
            }

            List<string> Mensajes = ExtraerFichero.ExtraerContenidoFichero(Ruta);
            if (Mensajes.Count() != 34)
            {
                error = true;
                switch (SeleccionIdioma)
                {
                    case "Español": Console.WriteLine("Error, el archivo Program_ES.txt no es válido\nFin del programa"); break; //Español
                    case "Ingles": Console.WriteLine("Error, Program_EN.txt file is invalid.\nEnd of program"); break; //Ingles
                }
            }
            return Mensajes;
        }

        /// <summary>
        /// esto sirve para presentar por pantalla las fechas que el usuario ha introducido
        /// </summary>
        /// <param name="Fecha"> La  Fecha que ha introducido </param>
        /// <param name="Mensajes"></param>
        public static string MostrarFechas(List<int> Fecha, List<string> Mensajes)
        {
            string cadena = Mensajes[0] + Fecha[0] + "-" + Fecha[1] + "-" + Fecha[2];
            Console.WriteLine(cadena);
            return cadena;
        }

        /// <summary>
        /// su función es presentar por pantalla los cálculos realizados de las diferencias
        /// </summary>
        /// <param name="DiferenciaEntreFechas"> el valor de la diferencia entre las dos fechas introducidas por el usuario</param>
        /// <param name="DiferenciaHoyFecha1"> el valor de la diferencia entre la primera fecha y la fecha actual </param>
        /// <param name="DiferenciaHoyFecha2">  el valor de la diferencia entre la segunda fecha y la fecha actual </param>
        /// <param name="Mensajes"></param>
        public static void MostrarEdades(string DiferenciaEntreFechas, string DiferenciaHoyFecha1, string DiferenciaHoyFecha2, List<string> Mensajes)
        {
            Console.WriteLine(Mensajes[1]);
            Console.WriteLine(DiferenciaEntreFechas);
            Console.WriteLine("\n ");
            Console.WriteLine(Mensajes[2]);
            Console.WriteLine(DiferenciaHoyFecha1);
            Console.WriteLine("\n ");
            Console.WriteLine(Mensajes[3]);
            Console.WriteLine("\n ");
            Console.WriteLine(DiferenciaHoyFecha2);
        }

        /// <summary>
        /// Solicitar un número para saber si la fecha está antes o después de Cristo
        /// </summary>
        /// <param name="Mensajes"></param>
        /// <returns> El valor 0 o 1 que indica el Periodo </returns>
        public static int SolicitarPeriodo(List<string> Mensajes)
        {
            int periodo = 0;
            bool leido = false;
            //Un bucle que hasta que no se verifique bien la entrada de datos no salimos por eso el booleano
            do
            {
                Console.WriteLine(Mensajes[4]);
                if (!int.TryParse(Console.ReadLine(), out periodo))
                {
                    Console.WriteLine(Mensajes[5]);
                    Console.WriteLine(Mensajes[6]);
                    Console.ReadKey();
                }
                else
                {
                    //El periodo no puede ser negativo y el usuario vuelve a introducir el dato
                    if (periodo < 0)
                    {
                        Console.WriteLine(Mensajes[7]);
                        Console.WriteLine(Mensajes[8]);
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
                                Console.WriteLine(Mensajes[9]);
                                Console.WriteLine(Mensajes[10]);
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
        /// <param name="Mensajes"></param>
        /// <returns> El valor del año de la fecha</returns>
        public static int SolicitarAnno(List<string> Mensajes)
        {
            int anno = 0;
            bool leido = false;
            //no salimos hasta que la entrada de datos esté correctamente
            do
            {
                Console.WriteLine(Mensajes[11]);
                if (!int.TryParse(Console.ReadLine(), out anno))
                {
                    Console.WriteLine(Mensajes[12]);
                    Console.WriteLine(Mensajes[13]);
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
                            Console.WriteLine(Mensajes[14]);
                            Console.WriteLine(Mensajes[15]);
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine(Mensajes[16]);
                        Console.WriteLine(Mensajes[17]);
                        Console.ReadKey();
                    }
                }
            } while (!leido);
            return anno;
        }

        /// <summary>
        /// Solicita el mes de la fecha
        /// </summary>
        /// <param name="Mensajes"></param>
        /// <returns> El valor del mes</returns>
        public static int SolicitarMes(List<string> Mensajes, string SeleccionIdioma)
        {
            int mes = 0;
            //creo un array en donde están los nombres de los meses, el objetivo es que el usuario introduzca el nombre del mes
            //y luego devolver con la posición del array que es lo que corresponde al número del mes


            //Le paso la "SeleccionIdioma" para saber que array de meses escoger, si la ingles o la español.
            string[] meses = SeleccionIdiomaMeses(SeleccionIdioma);
          
   
            bool leido = false;
            do
            {
                Console.WriteLine(Mensajes[18]);
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
                            Console.WriteLine(Mensajes[19]);
                            Console.WriteLine(Mensajes[20]);
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
        /// Una funcion que devuelve un array de meses del idioma seleccionado
        /// </summary>
        /// <param name="SeleccionIdioma"></param>
        /// <returns></returns>
        public static string[] SeleccionIdiomaMeses(string SeleccionIdioma)
        {
            string[] MesesSeleccion = new string[12];
            if (SeleccionIdioma.ToLower() == "español")
            {
                string[] meses = {"enero","febrero","marzo",
                "abril","mayo","junio","julio","agosto",
                    "septiembre","octubre","noviembre","diciembre"};
                MesesSeleccion = meses;
            }
            else
            {
                string[] months = {"january","february","march",
                "april","may","june","july","august",
                    "september","october","november","december"};
                MesesSeleccion = months;
            }
            return MesesSeleccion;
        }

        /// <summary>
        /// Se introduce por consola el numero del dia de la fecha
        /// </summary>
        /// <param name="mes"></param>
        /// <param name="anno"></param>
        /// <param name="Mensajes"></param>
        /// <returns>devuelve el día</returns>
        public static int IntroducirDia(int mes, int anno,List<string> Mensajes)
        {
            int dia;
            bool leido = false;
            do
            {
                Console.WriteLine(Mensajes[21], anno, mes);
                if (!Int32.TryParse(Console.ReadLine(), out dia))
                {
                    Console.WriteLine(Mensajes[22]);
                    Console.WriteLine(Mensajes[23]);
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
                        Console.WriteLine(Mensajes[24]);
                        Console.WriteLine(Mensajes[25]);
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
        /// <param name="Mensajes"></param>
        /// /// <returns>booleano para saber si el día no es correcto</returns>
        public static bool DiaFebrero(bool bisiesto, int dia,List<string> Mensajes)
        {
            bool Error;
            if (bisiesto)
            {
                if (dia <= 29)
                {
                    Error = false;
                }
                else
                {
                    Console.WriteLine(Mensajes[26]);
                    Console.WriteLine(Mensajes[27]);
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
                    Console.WriteLine(Mensajes[28]);
                    Console.WriteLine(Mensajes[29]);
                    Console.ReadKey();
                    Console.Clear();
                    Error = true;
                }
            }
            return Error;
        }
        /// <summary>
        /// Se encarga de verificar que en los meses impares cumpla el límite de los 31 días
        /// </summary>
        /// <param name="dia"></param>
        /// <param name="Mensajes"></param>
        /// <returns>booleano para saber si el día es correcto</returns>
        public static bool MesImpar(int dia, List<string> Mensajes)
        {
            bool Error;
            //en los meses impares del año los días son hasta 31
            if (dia <= 31)
            {
                Error = false;
            }
            else
            {
                Console.WriteLine(Mensajes[30]);
                Console.WriteLine(Mensajes[31]);
                Console.ReadKey();
                Console.Clear();
                Error = true;
            }
            return Error;
        }
        /// <summary>
        /// Se encarga de verificar que en los meses pares cumpla el límite de los 30 días
        /// </summary>
        /// <param name="dia"></param>
        /// <param name="Mensajes"></param>
        /// <returns>booleano para saber si el día es correcto</returns>
        public static bool MesPar(int dia, List<string> Mensajes)
        {
            bool Error;
            //en los meses pares del año los días son hasta 30
            if (dia <= 30)
            {
                Error = false;
            }
            else
            {
                Console.WriteLine(Mensajes[32]);
                Console.WriteLine(Mensajes[33]);
                Console.ReadKey();
                Console.Clear();
                Error = true;
            }
            return Error;
        }
    }
}
