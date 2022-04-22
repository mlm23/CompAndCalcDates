using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace innui.CompAndCalcDates
{
    class CalculoYMostradoDeFechas
    {
        /// <summary>
        /// Pide los periodos de cada fecha para luego mostrar su edad actual y la diferencia entre estas mismas
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Se crea dos numeros que representan el periodo para cada fecha
            int PeriodoFecha1 = inclui.CompAndCalcDates.MostradoFunciones.SolicitarPeriodo();
            inclui.CompAndCalcDates.PedirFechas.PrimeraFecha();
            List<int> Fecha1 = Funciones.RellenarArrays();
            inclui.CompAndCalcDates.PedirFechas.SegundaFecha();
            int PeriodoFecha2= inclui.CompAndCalcDates.MostradoFunciones.SolicitarPeriodo();
            //Se recoge los datos a lista para que sea más sencillo los cálculos
            List<int> Fecha2 = Funciones.RellenarArrays();
            List<int> FechaActual = Funciones.ObtenerFechaActual();

            //Ahora toca presentar por pantalla las fechas
            string fecha1 = inclui.CompAndCalcDates.MostradoFunciones.MostrarFechas(Fecha1);
            string fecha2 = inclui.CompAndCalcDates.MostradoFunciones.MostrarFechas(Fecha2);

            inclui.CompAndCalcDates.PedirFechas.Continuar();


            //Cálculos
            string DiferenciaFechas = Calculos.DiferenciasEntreFechas(Fecha1, Fecha2, PeriodoFecha1, PeriodoFecha2);
            string DiferenciaHoyFecha1 = Calculos.DiferenciaEntreHoy(Fecha1, PeriodoFecha1, FechaActual);
            string DiferenciaHoyFecha2 = Calculos.DiferenciaEntreHoy(Fecha2, PeriodoFecha2, FechaActual);
            //Ya terminado los cálculos presentamos por pantalla los resultados
            inclui.CompAndCalcDates.MostradoFunciones.MostrarEdades(DiferenciaFechas, DiferenciaHoyFecha1, DiferenciaHoyFecha2);
            Console.WriteLine("...");
            Console.ReadKey();

        }
    }
}
