using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP4.EF.Data;

namespace TP4.EF.Logic
{
    public class SuppliersLogic : BaseLogic, IABMLogic<Suppliers>
    {      
        public List<Suppliers> GetAll()
        {
            return context.Suppliers.ToList();
        }

        public void Add(Suppliers newSuppliers)
        {
            context.Suppliers.Add(newSuppliers);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Suppliers supplierAEliminar = context.Suppliers.Find(id);
            context.Suppliers.Remove(supplierAEliminar);
            context.SaveChanges();
        }

        public void Update(Suppliers supplier)
        {
            Suppliers suppliersUpdate = context.Suppliers.Find(supplier.SupplierID);

            suppliersUpdate.CompanyName = supplier.CompanyName;
            suppliersUpdate.Phone = supplier.Phone;
            context.SaveChanges();
        }

        public Suppliers Busqueda(int id)
        {
            Suppliers supplier = context.Suppliers.Find(id);
            if(supplier==null)

            {
                throw new Exception("Id no encontrado");
            }
            return supplier;
        }
    }
}
