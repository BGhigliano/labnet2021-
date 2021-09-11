using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ejercicio_2_poo.Tests
{
    [TestClass()]
    public class LogicTests
    {
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void RetornarExcepcionTest()
        {
            // arrange
            Logic logicTest = new Logic();

            //act
            logicTest.RetornarExcepcion();

        }

        [TestMethod()]
        [ExpectedException(typeof(ExcepcionPersonalizada))]
        public void RetornarExcepcionPersonalizadaTest()
        {
            Logic logicTest = new Logic();
            logicTest.RetornarExcepcionPersonalizada("base","agregado") ;
        }
    }
}