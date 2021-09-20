using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using TP4.EF.Data;


namespace TP4.EF.Logic.Tests
{
    [TestClass()]
    public class ShippersLogicTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            // arrange
            ShippersLogic shippersLogic = new ShippersLogic();
            NorthwindContext contexto = new NorthwindContext();
            List<Shippers> listaShippers = contexto.Shippers.ToList();

            // act

            List<Shippers> listado = shippersLogic.GetAll();

            // assert
            for(int i =0;i<listado.Count;i++)
              {
                  Assert.AreEqual<Shippers>(listado[0],listaShippers[0]);
              }
       
        }
    }
}