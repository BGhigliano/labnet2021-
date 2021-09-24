using System.Collections.Generic;
using System.Linq;
using TP5.LINQ.Data;
using TP5.LINQ.Entities;

namespace TP5.LINQ.Logic
{
    public class ProductsLogic : BaseLogic
    {
        public IQueryable <Products> ProductsWithoutStock()
        {

            return context.Products.Where(p=>p.UnitsInStock<=0);

        }
        public IQueryable<Products> ProductsWithStockAndPriceOverThree()
        {
            return context.Products.Where(p => p.UnitsInStock > 0 && p.UnitPrice>3);
        }

        public Products ProductsWithID789()
        {
            return context.Products.FirstOrDefault(p=>p.ProductID==789);
        }

        public List<Products> ProductsOrderedByName()
        {
            var query = (from p in context.Products
                         orderby p.ProductName
                         select p);

            return query.ToList();

        //    return context.Products.OrderBy(p => p.ProductName).ToList();
        }

        public IQueryable<Products> ProductsOrderedByStock()
        {
            var query = (from p in context.Products
                         orderby p.UnitsInStock descending
                         select p);
            return query;
           // return context.Products.OrderByDescending(p => p.UnitsInStock).ToList();
        }

        public IQueryable<Categories> DistinctCategories()
        {
            /*var query = (from Categories in context.Categories 
                         join Products in context.Products 
                         on Categories.CategoryID equals Products.CategoryID into cp
                         from catProd in cp.DefaultIfEmpty()
                         select new ProductCategoryDTO{
                         CategoryID=Categories.CategoryID,
                         CategoryName=Categories.CategoryName,
                         Description=Categories.Description,
                         Picture=Categories.Picture,
                         ProductID=catProd.ProductID,
                         ProductName=catProd.ProductName
                         });*/

            /*var query = (from Categories in context.Categories
                         join Products in context.Products
                         on Categories.CategoryID equals Products.CategoryID
                         group Categories by Categories into cat
                         select cat );*/

            var query2 =
                        from Categories in context.Categories
                        where (from Products in context.Products
                               select Products.CategoryID).Contains(Categories.CategoryID)
                        select Categories;

            return query2;
        }

        public Products FirstProduct()
        {
            var query = (from p in context.Products
                         select p).FirstOrDefault();

            return query;

        }


    }
}
