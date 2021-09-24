using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP5.LINQ.Entities;

namespace TP5.LINQ.Data
{
    public class OrderCustomerDTO
    {

        [Key]
        [StringLength(5)]
        public string CustomerID { get; set; }

        [Required]
        [StringLength(40)]
        public string CompanyName { get; set; }

        [StringLength(30)]
        public string ContactName { get; set; }

        [StringLength(30)]
        public string ContactTitle { get; set; }

        [StringLength(60)]
        public string Address { get; set; }

        [StringLength(15)]
        public string City { get; set; }

        [StringLength(15)]
        public string Region { get; set; }

        [StringLength(10)]
        public string PostalCode { get; set; }

        [StringLength(15)]
        public string Country { get; set; }

        [StringLength(24)]
        public string Phone { get; set; }

        [StringLength(24)]
        public string Fax { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }

        public virtual ICollection<CustomerDemographics> CustomerDemographics { get; set; }


        [Key]
        public int OrderID { get; set; }

        [StringLength(5)]
        public string Order_CustomerID { get; set; }

        public int? EmployeeID { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? RequiredDate { get; set; }

        public DateTime? ShippedDate { get; set; }

        public int? ShipVia { get; set; }

        [Column(TypeName = "money")]
        public decimal? Freight { get; set; }

        [StringLength(40)]
        public string ShipName { get; set; }

        [StringLength(60)]
        public string ShipAddress { get; set; }

        [StringLength(15)]
        public string ShipCity { get; set; }

        [StringLength(15)]
        public string ShipRegion { get; set; }

        [StringLength(10)]
        public string ShipPostalCode { get; set; }

        [StringLength(15)]
        public string ShipCountry { get; set; }

        public virtual Customers Customers { get; set; }

        public virtual Employees Employees { get; set; }

        public virtual ICollection<Order_Details> Order_Details { get; set; }

        public virtual Shippers Shippers { get; set; }

        public override bool Equals(object o)
        {
            var result = false;
            var project = o as OrderCustomerDTO;
            if (project != null)
            {
                result = CustomerID == project.CustomerID;
                result &= CompanyName == (project.CompanyName);
                result &= ContactName == (project.ContactName);
                result &= ContactTitle == (project.ContactTitle);
                result &= Address == (project.Address);
                result &= City == (project.City);
                result &= Region == (project.Region);
                result &= PostalCode == (project.PostalCode);
                result &= Country == (project.Country);
                result &= Phone == (project.Phone);
                result &= Fax == (project.Fax);

                result &= OrderID == (project.OrderID);
                result &= Order_CustomerID == (project.Order_CustomerID);
                result &= EmployeeID == (project.EmployeeID);
                result &= OrderDate == (project.OrderDate);
                result &= RequiredDate == (project.RequiredDate);
                result &= ShippedDate == (project.ShippedDate);
                result &= ShipVia == (project.ShipVia);
                result &= Freight == (project.Freight);
                result &= ShipName == (project.ShipName);

                result &= ShipAddress == (project.ShipAddress);
                result &= ShipCity == (project.ShipCity);
                result &= ShipRegion == (project.ShipRegion);
                result &= ShipPostalCode == (project.ShipPostalCode);
                result &= ShipCountry == (project.ShipCountry);

                return result;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hashCode = 1543406782;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CustomerID);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CompanyName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ContactName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ContactTitle);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Address);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(City);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Region);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PostalCode);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Country);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Phone);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Fax);
            hashCode = hashCode * -1521134295 + EqualityComparer<ICollection<Orders>>.Default.GetHashCode(Orders);
            hashCode = hashCode * -1521134295 + EqualityComparer<ICollection<CustomerDemographics>>.Default.GetHashCode(CustomerDemographics);
            hashCode = hashCode * -1521134295 + OrderID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Order_CustomerID);
            hashCode = hashCode * -1521134295 + EmployeeID.GetHashCode();
            hashCode = hashCode * -1521134295 + OrderDate.GetHashCode();
            hashCode = hashCode * -1521134295 + RequiredDate.GetHashCode();
            hashCode = hashCode * -1521134295 + ShippedDate.GetHashCode();
            hashCode = hashCode * -1521134295 + ShipVia.GetHashCode();
            hashCode = hashCode * -1521134295 + Freight.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ShipName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ShipAddress);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ShipCity);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ShipRegion);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ShipPostalCode);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ShipCountry);
            hashCode = hashCode * -1521134295 + EqualityComparer<Customers>.Default.GetHashCode(Customers);
            hashCode = hashCode * -1521134295 + EqualityComparer<Employees>.Default.GetHashCode(Employees);
            hashCode = hashCode * -1521134295 + EqualityComparer<ICollection<Order_Details>>.Default.GetHashCode(Order_Details);
            hashCode = hashCode * -1521134295 + EqualityComparer<Shippers>.Default.GetHashCode(Shippers);
            return hashCode;
        }
    }
}
