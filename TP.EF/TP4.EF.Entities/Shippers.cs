namespace TP4.EF.Logic
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Shippers
    {
        [Key]
        public int ShipperID { get; set; }

        [Required(ErrorMessage ="Debe indicarse un nombre de la compa��a")]
        [StringLength(40, ErrorMessage="El nombre de la empresa no debe superar los 40 caracteres")]
        public string CompanyName { get; set; }

        [StringLength(24,ErrorMessage = "El tel�fono no debe superar los 40 caracteres")]
        public string Phone { get; set; }
    }
}
