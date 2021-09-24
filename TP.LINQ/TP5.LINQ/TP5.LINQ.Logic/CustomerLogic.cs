using System;
using System.Collections.Generic;
using System.Linq;
using TP5.LINQ.Data;
using TP5.LINQ.Entities;

namespace TP5.LINQ.Logic
{
    public class CustomerLogic : BaseLogic
    {
        public Customers GetCustomer()
        {
            return context.Customers.FirstOrDefault();
            
        }
        public IQueryable<Customers> CustomersWA()
        {
            return context.Customers.Where(c=>c.Region=="WA");
        }
        public IQueryable<string> CustomersNames()
        {
            return context.Customers/*.OrderBy(c => c.CompanyName)*/.Select(c => c.CompanyName);
        }
        public IQueryable<OrderCustomerDTO> JoinOrdersCustomersWhere()
        {
            DateTime filter = new DateTime(1997,1,1);
            OrderCustomerDTO DTO = new OrderCustomerDTO();

            var query = context.Customers   
               .Join(context.Orders,       
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
               .Where(co => co.Region == "WA" && co.OrderDate > filter);
            
            return query;
        }
        public List<Customers> CustomersWATop3()
        {
            var query = (from c in context.Customers
                        where c.Region == "WA"
                        orderby c.CustomerID ascending
                        select c).Take(3);

            return query.ToList();
        }
        public IQueryable CustomersWithCountOrders()
        {
            var query = (from Customers in context.Customers
                         join Orders in context.Orders
                         on Customers.CustomerID equals Orders.CustomerID into co
                         select new CustomerCountOrderDTO
                         {
                             CustomerID = Customers.CustomerID,
                             CompanyName = Customers.CompanyName,
                             ContactName = Customers.ContactName,
                             ContactTitle = Customers.ContactTitle,
                             Address = Customers.Address,
                             City = Customers.City,
                             Region = Customers.Region,
                             PostalCode = Customers.PostalCode,
                             Country = Customers.Country,
                             Phone = Customers.Phone,
                             Fax = Customers.Fax,
                             Conteo = co.Count()
                         }
                         );

            return query;
        }

    }
}
