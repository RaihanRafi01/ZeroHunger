using Hunger.EF;
using Hunger.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hunger.Controllers
{
    public class InsController : Controller
    {
        // GET: Ins
        public ActionResult Index(int id)
        {
            TempData["UID"] = id;
            
            return View();
        }
        [HttpGet]
        public ActionResult ColReq()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ColReq(Collection coll)
        {
          
            DbClass db = new DbClass();
            Collection c = new Collection();
            int id = (int)TempData["UID"];
            c.Ins_id = id;
            c.FoodQty = coll.FoodQty;
            c.ReqDate = DateTime.Now;
            c.ExpDate = coll.ExpDate;
            c.Status= "Pending";
            db.Collections.Add(c);
            db.SaveChanges();
            return View();
        }
    }
}