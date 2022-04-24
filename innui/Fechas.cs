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
            //Guardamos en un string el idioma que elige el usario para el programa
            string SeleccionIdioma = inclui.CompAndCalcDates.Menu.OpcionUsuario();
            //Generamos una lista con los mensajes del idioma para la clase y solicitamos el periodo de la fecha
            List<string> MensajesMostrado = inclui.CompAndCalcDates.MostradoFunciones.SeleccionFecha(SeleccionIdioma);
            int PeriodoFecha1 = inclui.CompAndCalcDates.MostradoFunciones.SolicitarPeriodo(MensajesMostrado);
            //Generamos una lista con los mensajes del idioma para la clase y pedimos la  primera fecha
            List<string> MensajesPedir = inclui.CompAndCalcDates.PedirFechas.SeleccionFecha(SeleccionIdioma);
            inclui.CompAndCalcDates.PedirFechas.PrimeraFecha(MensajesPedir);

            //Se crea dos numeros que representan el periodo para cada fecha
            List<int> Fecha1 = Funciones.RellenarArrays(MensajesMostrado);
            //Pedimos la segunda fecha
            inclui.CompAndCalcDates.PedirFechas.SegundaFecha(MensajesPedir);
            //Solicitamos el periodo de la segunda fecha
            int PeriodoFecha2= inclui.CompAndCalcDates.MostradoFunciones.SolicitarPeriodo(MensajesMostrado);
            //Se recoge los datos a lista para que sea más sencillo los cálculos
            List<int> Fecha2 = Funciones.RellenarArrays(MensajesMostrado);
            List<int> FechaActual = Funciones.ObtenerFechaActual();

            //Ahora toca presentar por pantalla las fechas
            string fecha1 = inclui.CompAndCalcDates.MostradoFunciones.MostrarFechas(Fecha1, MensajesMostrado);
            string fecha2 = inclui.CompAndCalcDates.MostradoFunciones.MostrarFechas(Fecha2, MensajesMostrado);

            inclui.CompAndCalcDates.PedirFechas.Continuar(MensajesPedir);

            //Cálculos
            //Generamos la lista con el idioma seleccionado de la clase
            List<string> MensajesCalculos = inclui.CompAndCalcDates.VariablesCalculos.SeleccionFecha(SeleccionIdioma);
            //String de la diferencia de edad en dias y años entre las dos fechas
            string DiferenciaFechas = Calculos.DiferenciasEntreFechas(Fecha1, Fecha2, PeriodoFecha1, PeriodoFecha2, MensajesCalculos);
            //String de la edad de la primera fecha
            string DiferenciaHoyFecha1 = Calculos.DiferenciaEntreHoy(Fecha1, PeriodoFecha1, FechaActual, MensajesCalculos);
            ///string de la edad de la segunda fecha
            string DiferenciaHoyFecha2 = Calculos.DiferenciaEntreHoy(Fecha2, PeriodoFecha2, FechaActual, MensajesCalculos);
            //Ya terminado los cálculos presentamos por pantalla los resultados
            inclui.CompAndCalcDates.MostradoFunciones.MostrarEdades(DiferenciaFechas, DiferenciaHoyFecha1, DiferenciaHoyFecha2, MensajesMostrado);
            Console.WriteLine("...");
            Console.ReadKey();

        }
    }
}
