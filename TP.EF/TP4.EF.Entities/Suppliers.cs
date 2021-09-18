namespace TP4.EF.Logic
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Suppliers
    {
        [Key]
        public int SupplierID { get; set; }

        [Required(ErrorMessage ="Debe indicarse un nombre de empresa obligatoriamente")]
        [StringLength(40, ErrorMessage = "El nombre de la empresa no debe superar los 40 caracteres")]
        public string CompanyName { get; set; }

        [StringLength(30, ErrorMessage = "El nombre del contacto no debe superar los 30 caracteres")]
        public string ContactName { get; set; }

        [StringLength(30, ErrorMessage = "El t�tulo del contacto no debe superar los 30 caracteres")]
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

        [Column(TypeName = "ntext")]
        public string HomePage { get; set; }
    }
}
