using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ejercicio_2_poo.Extensions.Tests
{
    [TestClass()]
    public class IntegerExtensionsTests
    {
        [TestMethod()]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivisionPorCeroExcepcionTest()
        {
            //arrange   
            int intTesteo = 1;
            //act
            intTesteo.DivisionPorCero();
        }

        [TestMethod()]
        public void DivisionConParametrosTest()
        {
            //arrange   
            int intTesteo = 10;
            int intTesteo2 = 2;
            //act
            int resultado = intTesteo.DivisionConParametros(intTesteo2);
            //assert
            Assert.AreEqual(5, resultado);
        }
        [TestMethod()]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivisionConParametrosPorCeroTest()
            
        {
            //arrange   
            int intTesteo = 10;
            int intTesteo2 = 0;
            //act
            int resultado = intTesteo.DivisionConParametros(intTesteo2);
           
        }
    }
}