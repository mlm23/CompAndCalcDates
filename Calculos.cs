using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompAndCalcDates
{
     public class Calculos
    {
       /// <summary>
       /// Se encarga de calcular la diferencia entre la fecha que ha introducido el usuario hasta hoy, calculando la diferencia entre años y dias
       /// </summary>
       /// <param name="Fecha"></param>
       /// <param name="Periodo"></param>
       /// <param name="FechaActual"></param>
       /// <returns> La cadena  que  representa los resultados obtenidos</returns>
        public static string DiferenciaEntreHoy(List<int> Fecha, int Periodo, List<int> FechaActual)
        {
            string linea = "";
            int DiferenciaAños = HallarAños(Periodo, FechaActual, Fecha);
            int DiferenciaDias = HallarDiasHastaHoy(FechaActual, Fecha, Periodo,DiferenciaAños);
            //si la difencia es negativa , hacemos el valor absoluto para que la diferencia sea positiva
            DiferenciaAños = Math.Abs(DiferenciaAños);
            DiferenciaDias = Math.Abs(DiferenciaDias);
            //el string linea sirve concatenar el texto y los calculos realizados anteriormente para posteriormente mostrarlo por pantalla
            linea += " La diferencia entre la Fecha Actual  " + DiferenciaAños + " en años y con días " + DiferenciaDias;
            return linea;
        }
        /// <summary>
        ///  Se encarga de calcular la diferencia entre la fechas que se han introducido por usuario , calculando la diferencia entre años y dias
        /// </summary>
        /// <param name="Fecha1"></param>
        /// <param name="Fecha2"></param>
        /// <param name="Periodo1"></param>
        /// <param name="Periodo2"></param>
        /// <param name="FechaActual"></param>
        /// <returns> La cadena  que  representa los resultados obtenidos</returns>
        public static string DiferenciasEntreFechas(List<int> Fecha1, List<int> Fecha2, int Periodo1, int Periodo2)
        {
            string cadena = "";
            int DiferenciaAños = CalcularDiferenciaAños(Periodo1, Periodo2, Fecha1, Fecha2);
            int DiferenciaDias = CalcularDiferenciaDias(Fecha1, Fecha2, DiferenciaAños);
            DiferenciaAños = Math.Abs(DiferenciaAños);
            DiferenciaDias = Math.Abs(DiferenciaDias);
            cadena += " La diferencia entre ambas Fechas es " + DiferenciaAños + " en años y en días " + DiferenciaDias;
            return cadena;
        }

        /// <summary>
        /// Calcula la diferencia en años entre las fechas con la fecha actual
        /// </summary>
        /// <param name="Periodo"></param>
        /// <param name="FechaActual"></param>
        /// <param name="Fecha"></param>
        /// <returns> El valor de la diferencia</returns>
        public static int HallarAños(int Periodo, List<int>FechaActual, List<int>Fecha)
        {
            int años = 0;
            //Si la fecha introducida es después de Cristo, la diferencia sería restando los años
            if(Periodo==1)
            {
                años = FechaActual[0] - Fecha[0];
            }
            //Si la fecha introducida es antes de Cristo, la diferencia sería sumando los años
            if (Periodo==0)
            {
                años = FechaActual[0] + Fecha[0];
            }
            return años;
        }
        /// <summary>
        /// Calcula el total de días que han transcurrido entre la fecha introducida a la fecha actual
        /// </summary>
        /// <param name="FechaActual"></param>
        /// <param name="Fecha"></param>
        /// <param name="Periodo"></param>
        /// <returns> numero de dias totales</returns>
        public static int HallarDiasHastaHoy(List<int> FechaActual, List<int> Fecha, int Periodo, int difenciaAnno)
        {
            int dias = 0;
            //sumamos los años totales para calcular los dias totales bisiestos
            int AñosTotales = FechaActual[0] + Fecha[0];
            int diasBisiestos = 0;
            //Si es en la era de Cristo
            if(Periodo==1)
            {
                //recorremos hacia delante los años
                for (int contador = Fecha[0]; contador == AñosTotales; contador++)
                {
                    //Por cada año bisiesto sumamos un día
                    if (DateTime.IsLeapYear(contador))
                    {
                        diasBisiestos++;
                    }
                }
            }
            //Si es antes de Cristo
            if(Periodo==0)
            {
                //recoremos hacia atrás
                for (int contador = Fecha[0]; contador == AñosTotales; contador--)
                {
                    //Por cada año bisiesto sumamos un día
                    if (DateTime.IsLeapYear(contador))
                    {
                        diasBisiestos++;
                    }
                }
            }
            //generamos un array en donde se ve la cantidad total de días por cada mes
            int[] NDias = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int diastotales1 = 0;

            //Recorremos el año actual y sumamos los días ya transcurridos en lo que llevamos de año
            for (int contador = 0; contador < FechaActual[1]; contador++)
            {
                diastotales1 = diastotales1 + NDias[contador];
            }
            int diastotales2 = 0;
            //Recorre el año de la fecha introducida y se suma el valor de cada mes trancurrido
            for (int contador = 0; contador < Fecha[1]; contador++)
            {
                diastotales2 = diastotales2 + NDias[contador];
            }
            //La diferencia en años lo multiplicamos por 365, le sumamos los dias bisiestos, los dias transcurridos de la fecha de hoy, sumamos los dias del mes de la fecha actual
            //y luego restamos los dias del mes de la fecha introducida y sus dias totales de los meses de ese año que se habian transcurridos 
            dias = difenciaAnno* 365 + diasBisiestos + diastotales1 + FechaActual[2] - Fecha[2] - diastotales2;
            return dias;
        }
        /// <summary>
        /// Calcula la diferencia en años entre las dos fechas introducidas por consola
        /// </summary>
        /// <param name="periodo1"></param>
        /// <param name="periodo2"></param>
        /// <param name="Fecha1"></param>
        /// <param name="Fecha2"></param>
        /// <returns>El valor de la diferencia de años</returns>
        public static int CalcularDiferenciaAños(int periodo1, int periodo2, List<int>Fecha1, List<int>Fecha2)
        {
            int añosTotales = 0;
            if(periodo1==periodo2)//están en la misma Época , se restan los años
            {
                añosTotales=Fecha1[0] - Fecha2[0];
            }
            else
            {
                //si la primera fecha está en la era de Cristo y la segunda antes de cristo, ambas se restan
                if(periodo1==1 && periodo2==0)
                {
                    añosTotales = Fecha1[0] + Fecha2[0];
                }
                else
                {
                    //si la primera fecha está antes de Cristo y la segunda después de cristo, ambas se suman
                    if (periodo1==0 && periodo2==1)
                    {
                        añosTotales = Fecha1[0] + Fecha2[0];
                    }
                }
            }
            return añosTotales;
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
            int AñosTotales = Fecha1[0] + Fecha2[0];
            int diferencias = 0;
            int diasBisiestos = 0;
            //recorremos los años totales y vemos a cada año bisiesto sumamos un día
            for (int contador = Fecha1[0]; contador==AñosTotales; contador++)
            {
                if (DateTime.IsLeapYear(contador))
                {
                    diasBisiestos++;
                }
            }
            //generamos un array en donde se ve la cantidad total de días por cada mes
            int[] NDias = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int diastotales1 = 0;
            //Recorremos el año de la primera fecha y sumamos los días ya transcurridos en lo que llevamos de año
            for (int contador = 0; contador < Fecha1[1]; contador++)
            {
                diastotales1 = diastotales1 + NDias[contador];
            }
            //Recorre el año de la segunda fecha y se suma el valor de cada mes trancurrido
            int diastotales2 = 0;
            for (int contador = 0; contador < Fecha2[1]; contador++)
            {
                diastotales2 = diastotales2 + NDias[contador];
            }
            diferencias = diferenciaAnno * 365 + diasBisiestos + diastotales1 + Fecha1[2] - Fecha2[2] - diastotales2;
            return diferencias;
        }
    }
}
