using Hunger.EF;
using Hunger.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Hunger.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult DeliverView()
        {
            DbClass db = new DbClass();
            var list = db.Deliver_Reqs.ToList();
            return View(list);
        }

        public ActionResult PerformDeliver(int id)
        {
            DbClass db = new DbClass();
            Deliver_Req req = new Deliver_Req();
            var d = (from s in db.Deliver_Reqs
                       where s.Id == id
                       select s).SingleOrDefault();

            req.Id = d.Id;
            
            req.Employee_Assign_id= d.Employee_Assign_id;
            req.Name= d.Name;
            req.Resturant_Name = d.Resturant_Name;
            req.Food_Quality = d.Food_Quality;
            req.Expire_Date = d.Expire_Date;
            req.Assing_Date = d.Assing_Date; 
            req.Status_Delivery = "Completed";
            db.Entry(d).CurrentValues.SetValues(req);
            db.SaveChanges();
            db.Deliver_Reqs.Remove(d);
            db.SaveChanges();
            
            return RedirectToAction("DeliverView");

        }

    }
}