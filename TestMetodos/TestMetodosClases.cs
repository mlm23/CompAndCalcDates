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
        public void DiasAņosBisiesto1()
        {
            int periodo = 1;
            int anno = 2004;
            int annostotales = 2022;
            int diasAņosBisiestos = innui.CompAndCalcDates.Calculos.DiasBisiestosPorPeriodos(periodo, anno, annostotales);
            int diasEsperados = 5;
            Assert.AreEqual(diasAņosBisiestos, diasEsperados);
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
