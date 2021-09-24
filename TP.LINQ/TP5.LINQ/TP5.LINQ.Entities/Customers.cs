namespace TP5.LINQ.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Customers
    {

        public Customers()
        {
            Orders = new HashSet<Orders>();
            CustomerDemographics = new HashSet<CustomerDemographics>();
        }

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

        public override bool Equals(object o)
        {
            var result = false;
            var project = o as Customers;
            if (project != null)
            {
                result =    CustomerID== project.CustomerID;
                result &= CompanyName == (project.CompanyName);
                result &= ContactName == (project.ContactName);
                result &= ContactTitle == (project.ContactTitle);
                result &= Address == (project.Address);
                result &= City== (project.City);
                result &= Region==(project.Region);
                result &= PostalCode == (project.PostalCode);
                result &= Country == (project.Country);
                result &= Phone == (project.Phone);
                result &= Fax == (project.Fax);

                return result;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hashCode = 1976851938;
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
            return hashCode;
        }
    }
}
