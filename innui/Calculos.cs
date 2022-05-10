using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace innui.CompAndCalcDates
{
     public class Calculos
    {
        /// <summary>
        /// Se encarga de calcular la diferencia entre la fecha que ha introducido el usuario hasta hoy, calculando la diferencia entre años y dias
        /// </summary>
        /// <param name="Fecha"></param>
        /// <param name="Periodo"></param>
        /// <param name="FechaActual"></param>
        /// <param name="Mensajes"></param>
        /// <returns> La cadena  que  representa la edad de la fecha</returns>
        public static string DiferenciaEntreHoy(List<int> Fecha, int Periodo, List<int> FechaActual, List<string> MensajesCalculos)
        {
            string linea;
            int DiferenciaAnnos = HallarAnnos(Periodo, FechaActual, Fecha);
            int DiferenciaDias = HallarDiasHastaHoy(FechaActual, Fecha, Periodo,DiferenciaAnnos);
            //si la difencia es negativa , hacemos el valor absoluto para que la diferencia sea positiva
            DiferenciaAnnos = Math.Abs(DiferenciaAnnos);
            DiferenciaDias = Math.Abs(DiferenciaDias);
            //el string linea sirve concatenar el texto y los calculos realizados anteriormente para posteriormente mostrarlo por pantalla
            linea = inclui.CompAndCalcDates.VariablesCalculos.ConcatenarDiferenciaEntreHoy(DiferenciaAnnos, DiferenciaDias, MensajesCalculos);
            return linea;
        }
        /// <summary>
        ///  Se encarga de calcular la diferencia entre las dos fechas que se han introducido por el usuario , calculando la diferencia entre años y dias
        /// </summary>
        /// <param name="Fecha1"></param>
        /// <param name="Fecha2"></param>
        /// <param name="Periodo1"></param>
        /// <param name="Periodo2"></param>
        /// <param name="Mensajes"></param>
        /// <returns> La cadena  que  representa los resultados obtenidos</returns>
        public static string DiferenciasEntreFechas(List<int> Fecha1, List<int> Fecha2, int Periodo1, int Periodo2, List<string> Mensajes)
        {
            string cadena;
            int DiferenciaAnnos = CalcularDiferenciaAnnos(Periodo1, Periodo2, Fecha1, Fecha2);
            int DiferenciaDias = CalcularDiferenciaDias(Fecha1, Fecha2, DiferenciaAnnos);
            DiferenciaAnnos = Math.Abs(DiferenciaAnnos);
            DiferenciaDias = Math.Abs(DiferenciaDias);
            cadena = inclui.CompAndCalcDates.VariablesCalculos.ConcantenarDiferenciaEntreFechas(DiferenciaAnnos, DiferenciaDias, Mensajes);
            return cadena;
        }

        /// <summary>
        /// Calcula la diferencia en años entre la fecha con la fecha actual
        /// </summary>
        /// <param name="Periodo"></param>
        /// <param name="FechaActual"></param>
        /// <param name="Fecha"></param>
        /// <returns> El valor de la diferencia</returns>
        public static int HallarAnnos(int Periodo, List<int>FechaActual, List<int>Fecha)
        {
            int annos = 0;
            //Si la fecha introducida es después de Cristo, la diferencia sería restando los años
            if(Periodo==1)
            {
                annos = FechaActual[0] - Fecha[0];
            }
            //Si la fecha introducida es antes de Cristo, la diferencia sería sumando los años
            if (Periodo==0)
            {
                annos = FechaActual[0] + Fecha[0];
            }
            return annos;
        }
        /// <summary>
        /// Calcula el total de días que han transcurrido entre la fecha introducida a la fecha actual
        /// </summary>
        /// <param name="FechaActual"></param>
        /// <param name="Fecha"></param>
        /// <param name="Periodo"></param>
        /// <param name="difenciaAnno"></param>
        /// <returns> numero de dias totales</returns>
        public static int HallarDiasHastaHoy(List<int> FechaActual, List<int> Fecha, int Periodo, int difenciaAnno)
        {
            //sumamos los años totales para calcular los dias totales bisiestos
            int annostotales = FechaActual[0] + Fecha[0];
            //Sumados los días bisiestos de la fecha dependiendo del periodo
            int diasBisiestos = DiasBisiestosPorPeriodos(Periodo, Fecha[0],annostotales);           
            //Recorremos el año actual y sumamos los días ya transcurridos en lo que llevamos de año
            int diastotales1 = CalcularDiasTotales(FechaActual[1]);
            //Recorre el año de la fecha introducida y se suma el valor de cada mes trancurrido
            int diastotales2 = CalcularDiasTotales(Fecha[1]);
            //La diferencia en años lo multiplicamos por 365, le sumamos los dias bisiestos, los dias transcurridos de la fecha de hoy, sumamos los dias del mes de la fecha actual
            //y luego restamos los dias del mes de la fecha introducida y sus dias totales de los meses de ese año que se habian transcurridos 
            int dias = difenciaAnno* 365 + diasBisiestos + diastotales1 + FechaActual[2] - Fecha[2] - diastotales2;
            return dias;
        }
        /// <summary>
        /// Calcula los días de los años bisiestos de le feha segun su periodo
        /// </summary>
        /// <param name="Periodo"></param>
        /// <param name="anno"></param>
        /// <param name="annostotales"></param>
        /// <returns></returns>
        public static int DiasBisiestosPorPeriodos(int Periodo,int anno,int annostotales)
        {
            int diasBisiestos = 0;
            //Si es en la era de Cristo
            if (Periodo == 1)
            {
                //recorremos hacia delante los años
                for (int contador = anno; contador == annostotales; contador++)
                {
                    //Por cada año bisiesto sumamos un día
                    if (DateTime.IsLeapYear(contador))
                    {
                        diasBisiestos++;
                    }
                }
            }
            else//Es antes de Cristo
            {
                //recoremos hacia atrás
                for (int contador = anno; contador == annostotales; contador--)
                {
                    //Por cada año bisiesto sumamos un día
                    if (DateTime.IsLeapYear(contador))
                    {
                        diasBisiestos++;
                    }
                }
            }
            return diasBisiestos;
        }
        /// <summary>
        /// Calcula la diferencia en años entre las dos fechas introducidas por consola
        /// </summary>
        /// <param name="periodo1"></param>
        /// <param name="periodo2"></param>
        /// <param name="Fecha1"></param>
        /// <param name="Fecha2"></param>
        /// <returns>El valor de la diferencia de años</returns>
        public static int CalcularDiferenciaAnnos(int periodo1, int periodo2, List<int>Fecha1, List<int>Fecha2)
        {
            int annosTotales = 0;
            if(periodo1==periodo2)//están en la misma Época , se restan los años
            {
                annosTotales=Fecha1[0] - Fecha2[0];
            }
            else
            {
                //si la primera fecha está en la era de Cristo y la segunda antes de cristo, ambas se restan
                if(periodo1==1 && periodo2==0)
                {
                    annosTotales = Fecha1[0] + Fecha2[0];
                }
                else
                {
                    //si la primera fecha está antes de Cristo y la segunda después de cristo, ambas se suman
                    if (periodo1==0 && periodo2==1)
                    {
                        annosTotales = Fecha1[0] + Fecha2[0];
                    }
                }
            }
            return annosTotales;
        }
        /// <summary>
        /// El objetivo es calcular los días de difencecia entre ambas fechas introducida por el usuario
        /// </summary>
        /// <param name="Fecha1"></param>
        /// <param name="Fecha2"></param>
        /// <param name="diferenciaAnno"></param>
        /// <returns></returns>
        public static int CalcularDiferenciaDias(List<int> Fecha1, List<int> Fecha2, int diferenciaAnno)
        {
            //sumamos los años totales para calcular los dias totales bisiestos
            int AnnosTotales = Fecha1[0] + Fecha2[0];
            //recorremos los años totales y vemos a cada año bisiesto sumamos un día
            int diasBisiestos = CalcularDiasBisiestos(Fecha1[0], AnnosTotales);
            //Recorremos el año de la primera fecha y sumamos los días ya transcurridos en lo que llevamos de año
            int diastotales1 = CalcularDiasTotales(Fecha1[1]);
            //Recorre el año de la segunda fecha y se suma el valor de cada mes trancurrido
            int diastotales2 = CalcularDiasTotales(Fecha2[1]);
            int diferencias = diferenciaAnno * 365 + diasBisiestos + diastotales1 + Fecha1[2] - Fecha2[2] - diastotales2;
            return diferencias;
        }
        /// <summary>
        /// Función que devuelve los dias que faltan de los años bisiestos
        /// </summary>
        /// <param name="annoFecha">Año de la primera fecha</param>
        /// <param name="annosTotales">Años totales de las dos fechas sumadas</param>
        /// <returns></returns>
        public static int CalcularDiasBisiestos(int annoFecha,int annosTotales)
        {
            int diasBisiestos = 0;
            for (int contador = annoFecha; contador == annosTotales; contador++)
            {
                if (DateTime.IsLeapYear(contador))
                {
                    diasBisiestos++;
                }
            }
            return diasBisiestos;
        }
        /// <summary>
        /// Función que retorna los días transcurridos de una fecha
        /// </summary>
        /// <param name="mes"></param>
        /// <returns></returns>
        public static int CalcularDiasTotales(int mes)
        {
            //generamos un array en donde se ve la cantidad total de días por cada mes
            int[] NDias = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int diastotales = 0;
            for (int contador = 0; contador < mes; contador++)
            {
                diastotales += NDias[contador];
            }
            return diastotales;
        }
    }
}
