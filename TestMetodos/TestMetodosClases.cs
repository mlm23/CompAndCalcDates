using Microsoft.VisualStudio.TestTools.UnitTesting;
using innui.CompAndCalcDates;
using static innui.CompAndCalcDates.Funciones;
using static innui.CompAndCalcDates.Calculos;
namespace TestMetodos
{

    [TestClass]
    public class MetodosCalculos
    {
        [TestMethod]
        public void DiasA�osBisiesto1()
        {
            int periodo = 1;
            int anno = 2004;
            int annostotales = 2022;
            int diasA�osBisiestos = innui.CompAndCalcDates.Calculos.DiasBisiestosPorPeriodos(periodo, anno, annostotales);
            int diasEsperados = 5;
            Assert.AreEqual(diasA�osBisiestos, diasEsperados);
        }
    }

    [TestClass]
    public class MetodosFunciones
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
