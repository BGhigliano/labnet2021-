namespace TP5.LINQ.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Categories
    {
  
        public Categories()
        {
            Products = new HashSet<Products>();
        }
        
        [Key]
        public int CategoryID { get; set; }

        [Required]
        [StringLength(15)]
        public string CategoryName { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [Column(TypeName = "image")]
        public byte[] Picture { get; set; }
        public virtual ICollection<Products> Products { get; set; }

        public override bool Equals(object o)
        {
            var result = false;
            var project = o as Categories;
            if (project != null)
            {
                result = CategoryID == project.CategoryID;
                result &= CategoryName == (project.CategoryName);
                result &= Description == (project.Description);
                result &= Picture.SequenceEqual(project.Picture);

                return result;
            }
            return false;
        }
        public override int GetHashCode()
        {
            int hashCode = 296505877;
            hashCode = hashCode * -1521134295 + CategoryID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CategoryName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + EqualityComparer<byte[]>.Default.GetHashCode(Picture);
            hashCode = hashCode * -1521134295 + EqualityComparer<ICollection<Products>>.Default.GetHashCode(Products);
            return hashCode;
        }
    }
}
