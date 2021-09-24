using TP5.LINQ.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using TP5.LINQ.Data;
using TP5.LINQ.Entities;
using System;

namespace TP5.LINQ.Logic.Tests
{
    [TestClass()]
    public class CustomerLogicTests
    {
        [TestMethod()]
        public void ReturnCustomerTest()
        {
            //arrange
            Customers customerTest = new Customers();
            Customers customerTest2 = new Customers();
            CustomerLogic customerLogicTest = new CustomerLogic();
            NorthwindContext contextTest = new NorthwindContext();
            List<Customers> listado = contextTest.Customers.ToList();
            customerTest2 = listado[0];

            //act
            customerTest = customerLogicTest.GetCustomer();

            //assert
            Assert.AreEqual(customerTest2, customerTest);

        }

        [TestMethod()]
        public void CustomersWATest()
        {
            //arrange
            CustomerLogic customerLogicTest = new CustomerLogic();
            NorthwindContext contextTest = new NorthwindContext();
            List<Customers> listado = contextTest.Customers.ToList();

            for (int i = listado.Count - 1; i >= 0; i--)
            {
                if (listado[i].Region != "WA")
                {
                    listado.RemoveAt(i);
                }
            }
            //act
            List<Customers> listado2 = customerLogicTest.CustomersWA().ToList();

            //assert
            for (int i = 0; i < listado.Count; i++)
            {
                Assert.AreEqual(listado[i], listado2[i]);
            }
        }

        [TestMethod()]
        public void CustomersNamesUpperTest()
        {
            //arrange
            CustomerLogic customerLogicTest = new CustomerLogic();
            NorthwindContext contextTest = new NorthwindContext();
            List<Customers> listadoIntermedio = contextTest.Customers.ToList();
            List<string> listado = new List<string>();

            foreach (Customers item in listadoIntermedio)
            {
                listado.Add(item.CompanyName.ToString().ToUpper());
            }
            listado.Sort();
            //act
            List<string> listado2 = customerLogicTest.CustomersNames().ToList();

            //assert
            for (int i = 0; i < listado.Count; i++)
            {
                Assert.AreEqual(listado[i], listado2[i].ToUpper());
            }
        }
        [TestMethod()]
        public void CustomersNamesLowerTest()
        {
            //arrange
            CustomerLogic customerLogicTest = new CustomerLogic();
            NorthwindContext contextTest = new NorthwindContext();
            List<Customers> listadoIntermedio = contextTest.Customers.ToList();
            List<string> listado = new List<string>();

            foreach (Customers item in listadoIntermedio)
            {
                listado.Add(item.CompanyName.ToString().ToLower());
            }
            listado.Sort();
            //act
            List<string> listado2 = customerLogicTest.CustomersNames().ToList();

            //assert
            for (int i = 0; i < listado.Count; i++)
            {
                Assert.AreEqual(listado[i], listado2[i].ToLower());
            }
        }

        [TestMethod()]
        public void JoinOrdersCustomersWhereTest()
        {
            //arrange
            CustomerLogic customerLogicTest = new CustomerLogic();
            NorthwindContext contextTest = new NorthwindContext();
            DateTime filter = new DateTime(1997, 1, 1);


            var listado = contextTest.Customers
               .Join(contextTest.Orders,
                  c => c.CustomerID,
                  o => o.CustomerID,
                  (c, o) => new OrderCustomerDTO
                  {
                      CustomerID = c.CustomerID,
                      CompanyName = c.CompanyName,
                      ContactName = c.ContactName,
                      ContactTitle = c.ContactTitle,
                      Address = c.Address,
                      City = c.City,
                      Region = c.Region,
                      PostalCode = c.PostalCode,
                      Country = c.Country,
                      Phone = c.Phone,
                      Fax = c.Fax,
                      OrderID = o.OrderID,
                      Order_CustomerID = o.CustomerID,
                      EmployeeID = o.EmployeeID,
                      OrderDate = o.OrderDate,
                      RequiredDate = o.RequiredDate,
                      ShippedDate = o.ShippedDate,
                      ShipVia = o.ShipVia,
                      Freight = o.Freight,
                      ShipName = o.ShipName,
                      ShipAddress = o.ShipAddress,
                      ShipCity = o.ShipCity,
                      ShipRegion = o.ShipRegion,
                      ShipPostalCode = o.ShipPostalCode,
                      ShipCountry = o.ShipCountry

                  })
               .Where(co => co.Region == "WA" && co.OrderDate > filter)
               .ToList();


            //act
            List<OrderCustomerDTO> listado2 = customerLogicTest.JoinOrdersCustomersWhere().ToList();

            //assert

            for (int i = 0; i < listado.Count; i++)
            {
                Assert.AreEqual(listado[i], listado2[i]);
            }

        }

        [TestMethod()]
        public void CustomersWATop3Test()
        {
            //arrange
            CustomerLogic customerLogicTest = new CustomerLogic();
            NorthwindContext contextTest = new NorthwindContext();
            List<Customers> listado = contextTest.Customers.ToList();

            for (int i = listado.Count - 1; i >= 0; i--)
            {
                if (listado[i].Region != "WA")
                {
                    listado.RemoveAt(i);
                }
            }
            for (int i = listado.Count - 1; i >= 0; i--)
            {
                if (i > 3)
                {
                    listado.RemoveAt(i);
                }
            }
            //act
            List<Customers> listado2 = customerLogicTest.CustomersWATop3().ToList();

            //assert
            for (int i = 0; i < listado.Count; i++)
            {
                Assert.AreEqual(listado[i], listado2[i]);
            }
        }

        [TestMethod()]
        public void CustomersWithCountOrdersTest()
        {
            //arrange
            CustomerLogic customerLogicTest = new CustomerLogic();

            //act
            var listado2 = customerLogicTest.CustomersWithCountOrders();

            //assert

           
        }
    }
}