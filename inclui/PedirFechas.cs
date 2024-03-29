﻿using System;
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
        /// <param name="error"></param>
        /// <returns></returns>
        public static List<string> SeleccionFecha(string SeleccionIdioma,ref bool error)
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
            if(Mensajes.Count() != 3)
            {
                error = true;
                switch (SeleccionIdioma)
                {
                    case "Español": Console.WriteLine("Error, el archivo Program_ES.txt no es válido\nFin del programa"); break; //Español
                    case "Ingles": Console.WriteLine("Error, Program_ES.txt file is invalid.\nEnd of program"); break; //Ingles
                }
            }
            return Mensajes;
        }
        /// <summary>
        /// Muestra la solicitud de la primera fecha
        /// </summary>
        /// <param name="Mensajes"></param>
        public static void PrimeraFecha(List<string> Mensajes)
        {
            Console.WriteLine(Mensajes[0]);
        }
        /// <summary>
        /// Muestra la solicitud de la segunda fecha
        /// </summary>
        /// <param name="Mensajes"></param>
        public static void SegundaFecha(List<string> Mensajes)
        {
            Console.WriteLine(Mensajes[1]);
        }
        /// <summary>
        /// Espera la continuación del ususario por teclado
        /// </summary>
        /// <param name="Mensajes"></param>
        public static void Continuar(List<string> Mensajes)
        {
            Console.WriteLine(Mensajes[2]);
            Console.ReadKey();
            Console.Clear();
        }
    }
}
