using Hunger.EF;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult PerformDeliver()
        {
            DbClass db = new DbClass();
            var list = db.DeliverReqs.ToList();
            return View(list);
        }

    }
}