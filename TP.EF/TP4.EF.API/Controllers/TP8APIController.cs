using System.Collections.Generic;
using System.Web.Http;
using TP4.EF.API.Models;
using TP4.EF.Entities;
using TP4.EF.Logic;

namespace TP4.EF.API.Controllers
{
    public class TP8APIController : ApiController
    {
        ShippersLogic shippersLogic = new ShippersLogic();

        public IHttpActionResult GetAllShippers()
        {
            List<Shippers> shippers = shippersLogic.GetAll();
            List<ShippersView> shippersView = new List<ShippersView>();

            foreach (Shippers s in shippers)
            {
                shippersView.Add(new ShippersView {
                    ShipperID = s.ShipperID, 
                    CompanyName = s.CompanyName, 
                    Phone = s.Phone });
            }

            if (shippersView.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(shippersView);
            }
         }

        public IHttpActionResult AddNewShipper(ShippersView shipper)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            shippersLogic.Add(new Shippers
            {
                ShipperID = shipper.ShipperID,
                CompanyName = shipper.CompanyName,
                Phone = shipper.Phone
            });
            return Ok();
        }

        public IHttpActionResult DeleteShipper(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            shippersLogic.Delete(id);
            return Ok();
        }

        public IHttpActionResult PutShipper(ShippersView shipperView)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            Shippers shipper = new Shippers
            {
                ShipperID=shipperView.ShipperID,
                CompanyName=shipperView.CompanyName,
                Phone=shipperView.Phone
            };

           if(shippersLogic.Busqueda(shipper.ShipperID)==null)
            {
                return NotFound();
            }
            else
            {
                shippersLogic.Update(shipper);
            }
            return Ok();
        }

    }
}
