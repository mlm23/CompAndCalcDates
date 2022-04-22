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
            
            string SeleccionIdioma = inclui.CompAndCalcDates.Menu.OpcionUsuario();

            List<string> MensajesMostrado = inclui.CompAndCalcDates.MostradoFunciones.SeleccionFecha(SeleccionIdioma);
            int PeriodoFecha1 = inclui.CompAndCalcDates.MostradoFunciones.SolicitarPeriodo(MensajesMostrado);

            List<string> MensajesPedir = inclui.CompAndCalcDates.PedirFechas.SeleccionFecha(SeleccionIdioma);
            inclui.CompAndCalcDates.PedirFechas.PrimeraFecha(MensajesPedir);

            //Se crea dos numeros que representan el periodo para cada fecha
            List<int> Fecha1 = Funciones.RellenarArrays(MensajesMostrado);
            inclui.CompAndCalcDates.PedirFechas.SegundaFecha(MensajesPedir);
            int PeriodoFecha2= inclui.CompAndCalcDates.MostradoFunciones.SolicitarPeriodo(MensajesMostrado);
            //Se recoge los datos a lista para que sea más sencillo los cálculos
            List<int> Fecha2 = Funciones.RellenarArrays(MensajesMostrado);
            List<int> FechaActual = Funciones.ObtenerFechaActual();

            //Ahora toca presentar por pantalla las fechas
            string fecha1 = inclui.CompAndCalcDates.MostradoFunciones.MostrarFechas(Fecha1, MensajesMostrado);
            string fecha2 = inclui.CompAndCalcDates.MostradoFunciones.MostrarFechas(Fecha2, MensajesMostrado);

            inclui.CompAndCalcDates.PedirFechas.Continuar(MensajesPedir);


            //Cálculos
            List<string> MensajesCalculos = inclui.CompAndCalcDates.VariablesCalculos.SeleccionFecha(SeleccionIdioma);
            string DiferenciaFechas = Calculos.DiferenciasEntreFechas(Fecha1, Fecha2, PeriodoFecha1, PeriodoFecha2, MensajesCalculos);
            string DiferenciaHoyFecha1 = Calculos.DiferenciaEntreHoy(Fecha1, PeriodoFecha1, FechaActual, MensajesCalculos);
            string DiferenciaHoyFecha2 = Calculos.DiferenciaEntreHoy(Fecha2, PeriodoFecha2, FechaActual, MensajesCalculos);
            //Ya terminado los cálculos presentamos por pantalla los resultados
            inclui.CompAndCalcDates.MostradoFunciones.MostrarEdades(DiferenciaFechas, DiferenciaHoyFecha1, DiferenciaHoyFecha2, MensajesMostrado);
            Console.WriteLine("...");
            Console.ReadKey();

        }
    }
}
