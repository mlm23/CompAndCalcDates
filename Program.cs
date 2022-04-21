using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompAndCalcDates
{
    class Program
    {
        static void Main(string[] args)
        {
            const string NombreFichero = "TextoEspannol.txt";


            ExtraerFichero.ExtraerFicheroEspannol(NombreFichero);
            //Se crea dos numeros que representan el periodo para cada fecha
            int PeriodoFecha1 = Funciones.SolicitarPeriodo();
            Console.WriteLine("A continuación se introducirá la primera fecha");
            List<int> Fecha1 = Funciones.RellenarArrays();
            Console.WriteLine("A continuación se introducirá la segunda fecha");
            int PeriodoFecha2= Funciones.SolicitarPeriodo();
            //Se recoge los datos a lista para que sea más sencillo los cálculos
            List<int> Fecha2 = Funciones.RellenarArrays();
            List<int> FechaActual = Funciones.ObtenerFechaActual();

            //Ahora toca presentar por pantalla las fechas
            string fecha1 = Funciones.MostrarFechas(Fecha1);
            string fecha2 = Funciones.MostrarFechas(Fecha2);
           
            Console.WriteLine("pulse para continuar");
            Console.ReadKey();
            Console.Clear();

            //Cálculos
            string DiferenciaFechas = Calculos.DiferenciasEntreFechas(Fecha1, Fecha2, PeriodoFecha1, PeriodoFecha2);
            string DiferenciaHoyFecha1 = Calculos.DiferenciaEntreHoy(Fecha1, PeriodoFecha1, FechaActual);
            string DiferenciaHoyFecha2 = Calculos.DiferenciaEntreHoy(Fecha2, PeriodoFecha2, FechaActual);
            //Ya terminado los cálculos presentamos por pantalla los resultados
            Funciones.MostrarEdades(DiferenciaFechas, DiferenciaHoyFecha1, DiferenciaHoyFecha2);
            Console.WriteLine("...");
            Console.ReadKey();

        }
    }
}
