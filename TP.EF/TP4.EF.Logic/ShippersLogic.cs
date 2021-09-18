using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP4.EF.Data;
using TP4.EF.Logic;

namespace TP4.EF.Logic
{
    public class ShippersLogic : BaseLogic, IABMLogic<Shippers>
    {
    
        public List<Shippers> GetAll()

        {
            return context.Shippers.ToList();
        }

        public void Add(Shippers newShipper)
        {
            context.Shippers.Add(newShipper);
            context.SaveChanges(); 
        }

        public void Delete(int id)
        {
            Shippers shipperAEliminar = context.Shippers.Find(id);
            try
            {
                context.Shippers.Remove(shipperAEliminar);

            }
            catch (Exception e)
            {
                throw  new Exception("Id incorrecto");
            }

            context.SaveChanges();
        }

        public void Update(Shippers shipper)
        {
            Shippers shipperUpdate = context.Shippers.Find(shipper.ShipperID);
           shipperUpdate.CompanyName = shipper.CompanyName;
            shipper.Phone = shipper.Phone;
            context.SaveChanges();
        }

        public Shippers Busqueda(int id)
        {
            Shippers shipper = context.Shippers.Find(id);
            if (shipper == null)

            {
                throw new Exception("Id no encontrado");
            }
            return shipper;
        }
    }
}

