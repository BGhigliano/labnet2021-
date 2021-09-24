namespace TP5.LINQ.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Products
    {
        public Products()
        {
            Order_Details = new HashSet<Order_Details>();
        }

        [Key]
        public int ProductID { get; set; }

        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }

        public int? SupplierID { get; set; }

        public int? CategoryID { get; set; }

        [StringLength(20)]
        public string QuantityPerUnit { get; set; }

        [Column(TypeName = "money")]
        public decimal? UnitPrice { get; set; }

        public short? UnitsInStock { get; set; }

        public short? UnitsOnOrder { get; set; }

        public short? ReorderLevel { get; set; }

        public bool Discontinued { get; set; }

        public virtual Categories Categories { get; set; }

        public virtual ICollection<Order_Details> Order_Details { get; set; }

        public virtual Suppliers Suppliers { get; set; }
        public override bool Equals(object o)
        {
            var result = false;
            var project = o as Products;
            if (project != null)
            {
                result = ProductID == project.ProductID;
                result &= ProductName == (project.ProductName);
                result &= SupplierID == (project.SupplierID);
                result &= CategoryID == (project.CategoryID);
                result &= QuantityPerUnit == (project.QuantityPerUnit);
                result &= UnitPrice == (project.UnitPrice);
                result &= UnitsInStock == (project.UnitsInStock);
                result &= UnitsOnOrder == (project.UnitsOnOrder);
                result &= ReorderLevel == (project.ReorderLevel);
                result &= Discontinued == (project.Discontinued);
               
                return result;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hashCode = -434530832;
            hashCode = hashCode * -1521134295 + ProductID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ProductName);
            hashCode = hashCode * -1521134295 + SupplierID.GetHashCode();
            hashCode = hashCode * -1521134295 + CategoryID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(QuantityPerUnit);
            hashCode = hashCode * -1521134295 + UnitPrice.GetHashCode();
            hashCode = hashCode * -1521134295 + UnitsInStock.GetHashCode();
            hashCode = hashCode * -1521134295 + UnitsOnOrder.GetHashCode();
            hashCode = hashCode * -1521134295 + ReorderLevel.GetHashCode();
            hashCode = hashCode * -1521134295 + Discontinued.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Categories>.Default.GetHashCode(Categories);
            hashCode = hashCode * -1521134295 + EqualityComparer<ICollection<Order_Details>>.Default.GetHashCode(Order_Details);
            hashCode = hashCode * -1521134295 + EqualityComparer<Suppliers>.Default.GetHashCode(Suppliers);
            return hashCode;
        }
    }
}
