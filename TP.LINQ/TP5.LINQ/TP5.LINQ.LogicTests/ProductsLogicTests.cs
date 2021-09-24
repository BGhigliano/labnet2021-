using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP5.LINQ.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP5.LINQ.Entities;
using TP5.LINQ.Data;

namespace TP5.LINQ.Logic.Tests
{
    [TestClass()]
    public class ProductsLogicTests
    {
        [TestMethod()]
        public void ProductsWithoutStockTest()
        {
            //arrange
            ProductsLogic productsLogic = new ProductsLogic();
            NorthwindContext contextTest = new NorthwindContext();
            List<Products> listado = contextTest.Products.ToList();
            for (int i = listado.Count - 1; i >= 0; i--)
            {
                if (listado[i].UnitsInStock > 0)
                {
                    listado.RemoveAt(i);
                }
            }
            //act
            List<Products> listado2 = productsLogic.ProductsWithoutStock().ToList();
            //assert
            for (int i = 0; i < listado.Count; i++)
            {
                Assert.AreEqual(listado[i], listado2[i]);
            }

        }

        [TestMethod()]
        public void ProductsWithStockAndPriceOverThreeTest()
        {
            //arrange
            ProductsLogic productsLogic = new ProductsLogic();
            NorthwindContext contextTest = new NorthwindContext();
            List<Products> listado = contextTest.Products.ToList();
            for (int i = listado.Count - 1; i >= 0; i--)
            {
                if (listado[i].UnitsInStock == 0 || listado[i].UnitPrice < 3)
                {
                    listado.RemoveAt(i);
                }
            }
            //act
            List<Products> listado2 = productsLogic.ProductsWithStockAndPriceOverThree().ToList();

            //assert
            for (int i = 0; i < listado.Count; i++)
            {
                Assert.AreEqual(listado[i], listado2[i]);
            }
        }

        [TestMethod()]
        public void ProductsWithID789Test()
        {
            ProductsLogic productsLogic = new ProductsLogic();
            NorthwindContext contextTest = new NorthwindContext();
            Products productoTest1 = contextTest.Products.Find(789);

            //act
            Products productoTest2 = productsLogic.ProductsWithID789();

            //assert
            Assert.AreEqual(productoTest1, productoTest2);
        }

        [TestMethod()]
        public void ProductsOrderedByNameTest()
        {
            //arrange
            ProductsLogic productsLogic = new ProductsLogic();
            NorthwindContext contextTest = new NorthwindContext();
            List<Products> listado = contextTest.Products.OrderBy(p => p.ProductName).ToList();

            //act
            List<Products> listado2 = productsLogic.ProductsOrderedByName().ToList();

            //assert
            for (int i = 0; i < listado.Count; i++)
            {
                Assert.AreEqual(listado[i], listado2[i]);
            }
        }

        [TestMethod()]
        public void ProductsOrderedByStockTest()
        {
            //arrange
            ProductsLogic productsLogic = new ProductsLogic();
            NorthwindContext contextTest = new NorthwindContext();
            List<Products> listado = contextTest.Products.OrderByDescending(p => p.UnitsInStock).ToList();

            //act
            List<Products> listado2 = productsLogic.ProductsOrderedByStock().ToList();

            //assert
            for (int i = 0; i < listado.Count; i++)
            {
                Assert.AreEqual(listado[i], listado2[i]);
            }
        }

        [TestMethod()]
        public void DistinctCategoriesTest()
        {
            ProductsLogic productsLogic = new ProductsLogic();
            NorthwindContext contextTest = new NorthwindContext();
            List<Categories> listado = contextTest.Categories.ToList();
            List<int?> idsCategoriasVinculadas = contextTest.Products.Select(p => p.CategoryID).ToList();
            for (int i = listado.Count - 1; i >= 0; i--)
            {
                if (idsCategoriasVinculadas.Contains(listado[i].CategoryID) == false)
                {
                    listado.RemoveAt(i);
                }
            }

            //act
            List<Categories> listado2 = productsLogic.DistinctCategories().ToList();

            //assert
            for (int i = 0; i < listado.Count; i++)
            {
                Assert.AreEqual(listado[i], listado2[i]);
            }

        }

        [TestMethod()]
        public void FirstProductTest()
        {   
            //arrange
            ProductsLogic productsLogic = new ProductsLogic();
            NorthwindContext contextTest = new NorthwindContext();
            Products product1 = contextTest.Products.FirstOrDefault();

            //act
            Products product2 = productsLogic.FirstProduct();

            //assert
            Assert.AreEqual(product1, product2);
        }
    }
}