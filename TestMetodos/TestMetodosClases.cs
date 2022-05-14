using Microsoft.VisualStudio.TestTools.UnitTesting;
using innui.CompAndCalcDates;
using static innui.CompAndCalcDates.Funciones;
using static innui.CompAndCalcDates.Calculos;
using System.Collections.Generic;
using System;

namespace TestMetodos
{
    /// <summary>
    /// Clase para comprobar los métodos de Calculos
    /// </summary>
    [TestClass]
    public class MetodosCalculos
    {
        /// <summary>
        /// Comprobar que se calculan bien los años extras por ser bisiestos
        /// </summary>
        [TestMethod]
        public void DiasAnnosBisiesto1()
        {
            int anno = 2004;
            int annostotales = 2022;
            int diasAñosBisiestos = innui.CompAndCalcDates.Calculos.CalcularDiasBisiestos(anno, annostotales);
            int diasEsperados = 5;
            Assert.AreEqual(diasAñosBisiestos, diasEsperados);
        }

        /// <summary>
        /// Comprobar que se calculan bien los años extras por ser bisiestos
        /// </summary>
        [TestMethod]
        public void DiasAnnosBisiesto2()
        {
            int anno = 1500;
            int annostotales = 2022;
            int diasAñosBisiestos = innui.CompAndCalcDates.Calculos.CalcularDiasBisiestos(anno, annostotales);
            int diasEsperados = 127;
            Assert.AreEqual(diasAñosBisiestos, diasEsperados);
        }

        /// <summary>
        /// Comprobar que se calculan bien los dias hasta un mes
        /// </summary>
        [TestMethod]
        public void DiasHastaMes1()
        {
            int mes = 5;
            int diasAñosBisiestos = innui.CompAndCalcDates.Calculos.CalcularDiasTotales(mes);
            int diasEsperados = 151;
            Assert.AreEqual(diasAñosBisiestos, diasEsperados);
        }

        /// <summary>
        /// Comprobar que se calculan bien los dias hasta un mes
        /// </summary>
        [TestMethod]
        public void DiasHastaMes2()
        {
            int mes = 1;
            int diasAñosBisiestos = innui.CompAndCalcDates.Calculos.CalcularDiasTotales(mes);
            int diasEsperados = 31;
            Assert.AreEqual(diasAñosBisiestos, diasEsperados);
        }

        /// <summary>
        /// Comprobar que se calculan bien los dias hasta un mes
        /// </summary>
        [TestMethod]
        public void DiasHastaMes3()
        {
            int mes = 12;
            int diasAñosBisiestos = innui.CompAndCalcDates.Calculos.CalcularDiasTotales(mes);
            int diasEsperados = 365;
            Assert.AreEqual(diasAñosBisiestos, diasEsperados);
        }
        /// <summary>
        /// Comprobar los dias de una fecha hasta hoy 
        /// </summary>
        [TestMethod]
        public void DiasHastaHoy1()
        {
            int diferencianno = 51;
            List<int> FechaActual = new List<int>() { 2022, 05, 14 };
            List<int> Fecha = new List<int>() { 1950, 11, 23 };
            int annostotales = innui.CompAndCalcDates.Calculos.HallarDiasHastaHoy(FechaActual, Fecha, diferencianno);
            int diasEsperados = 18914;
            Assert.AreEqual(annostotales, diasEsperados);
        }

        /// <summary>
        /// Comprobar los dias de una fecha hasta hoy 
        /// </summary>
        [TestMethod]
        public void DiasHastaHoy2()
        {
            int diferencianno = 3951;
            List<int> FechaActual = new List<int>() { 2022, 05, 14 };
            List<int> Fecha = new List<int>() { 1950, 11, 23 };
            int annostotales = innui.CompAndCalcDates.Calculos.HallarDiasHastaHoy(FechaActual, Fecha, diferencianno);
            int diasEsperados = 1442414;
            Assert.AreEqual(annostotales, diasEsperados);
        }

        /// <summary>
        /// Comprobar los dias de diferencia de dos fechas(mismo periodo) 
        /// </summary>
        [TestMethod]
        public void DiferenciaDias1()
        {
            int diferencianno = 51;
            List<int> Fecha1 = new List<int>() { 2001, 11, 23 };
            List<int> Fecha2 = new List<int>() { 1950, 11, 23 };
            int annostotales = innui.CompAndCalcDates.Calculos.CalcularDiferenciaDias(Fecha1, Fecha2,diferencianno);
            int diasEsperados = 19087;
            Assert.AreEqual(annostotales, diasEsperados);
        }

        /// <summary>
        /// Comprobar los dias de diferencia de dos fechas(distinto periodo)
        /// </summary>
        [TestMethod]
        public void DiferenciaDias2()
        {
            int diferencianno = 3951;
            List<int> Fecha1 = new List<int>() { 2001, 11, 23 };
            List<int> Fecha2 = new List<int>() { 1950, 11, 23 };
            int annostotales = innui.CompAndCalcDates.Calculos.CalcularDiferenciaDias(Fecha1, Fecha2, diferencianno);
            int diasEsperados = 1442587;
            Assert.AreEqual(annostotales, diasEsperados);
        }
        /// <summary>
        /// Comprobar los años de dos fechas de después de cristo
        /// </summary>
        [TestMethod]
        public void DiferenciaAnnos1()
        {
            int periodo1 = 1;
            int periodo2 = 1;
            List<int> Fecha1 = new List<int>() { 2001,11,23};
            List<int> Fecha2 = new List<int>() { 1950, 11, 23 };
            int annostotales = innui.CompAndCalcDates.Calculos.CalcularDiferenciaAnnos(periodo1,periodo2,Fecha1,Fecha2);
            int annosEsperados = 51;
            Assert.AreEqual(annostotales, annosEsperados);
        }
        /// <summary>
        /// Comprobar los años de dos fechas de distinto periodo
        /// </summary>
        [TestMethod]
        public void DiferenciaAnnos2()
        {
            int periodo1 = 0;
            int periodo2 = 1;
            List<int> Fecha1 = new List<int>() { 2001, 11, 23 };
            List<int> Fecha2 = new List<int>() { 1950, 11, 23 };
            int annostotales = innui.CompAndCalcDates.Calculos.CalcularDiferenciaAnnos(periodo1, periodo2, Fecha1, Fecha2);
            int annosEsperados = 3951;
            Assert.AreEqual(annostotales, annosEsperados);
        }
        /// <summary>
        /// Comprobar los años de dos fechas antes de cristo
        /// </summary>
        [TestMethod]
        public void DiferenciaAnnos3()
        {
            int periodo1 = 0;
            int periodo2 = 0;
            List<int> Fecha1 = new List<int>() { 2001, 11, 23 };
            List<int> Fecha2 = new List<int>() { 1950, 11, 23 };
            int annostotales = innui.CompAndCalcDates.Calculos.CalcularDiferenciaAnnos(periodo1, periodo2, Fecha1, Fecha2);
            int annosEsperados = 51;
            Assert.AreEqual(annostotales, annosEsperados);
        }
    }
    /// <summary>
    /// Clase para comprobar los métodos de Funciones
    /// </summary>
    [TestClass]
    public class MetodosFunciones
    {
        /// <summary>
        /// Comprueba que devuelva correctamente si un año es bisiesto
        /// </summary>
        [TestMethod]
        public void AnnoBisiesto1()
        {
            int anno = 1904;
            bool bisiesto = innui.CompAndCalcDates.Funciones.Comprobarbisiesto(anno);
            Assert.IsTrue(bisiesto);
        }

        /// <summary>
        /// Comprueba que devuelva correctamente si un año es bisiesto
        /// </summary>
        [TestMethod]
        public void AnnoBisiesto2()
        {
            int anno = 5000;
            bool bisiesto = innui.CompAndCalcDates.Funciones.Comprobarbisiesto(anno);
            Assert.IsFalse(bisiesto);
        }

        /// <summary>
        /// Comprueba que devuelva correctamente si un año es bisiesto
        /// </summary>
        [TestMethod]
        public void AnnoBisiesto3()
        {
            int anno = 2004;
            bool bisiesto = innui.CompAndCalcDates.Funciones.Comprobarbisiesto(anno);
            Assert.IsTrue(bisiesto);
        }

    }
}
