using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP4.EF.Logic;
using TP4.EF.Entities;
using TP4.EF.MVC.Models;

namespace TP4.EF.MVC.Controllers
{
    public class ShippersController : Controller
    {
        ShippersLogic shippersLogic = new ShippersLogic();
        // GET: Shippers
        public ActionResult Index()
        {
            List<Shippers> shippers = shippersLogic.GetAll();
            List<ShippersView> shippersViews = shippers.Select(s => new ShippersView
            {
                ShipperID = s.ShipperID,
                CompanyName = s.CompanyName,
                Phone = s.Phone
            }).ToList();

            return View(shippersViews);
        }

        /*[HttpPost]
        public ActionResult Index()
        {
            List<Shippers> shippers = shippersLogic.GetAll();
            List<ShippersView> shippersViews = shippers.Select(s => new ShippersView
            {
                ShipperID = s.ShipperID,
                CompanyName = s.CompanyName,
                Phone = s.Phone
            }).ToList();

            return View(shippersViews);
        }*/

        [HttpGet]
        public ActionResult InsertUpdate(ShippersView shippersView)
        {
           
             return View(shippersView);

        }
       
        [HttpPost]
        public ActionResult InsertUpdate(ShippersView shippersView, string insertUpdate)
        {
            if(shippersView.Modificar=="Mod")
            {
                try
                {
                    Shippers shipperEntity = new Shippers
                    {
                        ShipperID=shippersView.ShipperID,
                        CompanyName = shippersView.CompanyName,
                        Phone = shippersView.Phone
                    };

                    shippersLogic.Update(shipperEntity);

                    return RedirectToAction("Index");
                }
                catch
                {
                    return RedirectToAction("Index", "Error");
                }
            }
            else
            {
                try
                {
                    Shippers shipperEntity = new Shippers
                    {
                        CompanyName = shippersView.CompanyName,
                        Phone = shippersView.Phone
                    };

                    shippersLogic.Add(shipperEntity);

                    return RedirectToAction("Index");
                }
                catch
                {
                    return RedirectToAction("Index", "Error");
                }

            }
            

        }

        public ActionResult Delete(int id)
        {
            shippersLogic.Delete(id);
            return RedirectToAction("Index");
        }
    }
}