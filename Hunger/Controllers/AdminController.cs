using Hunger.EF;
using Hunger.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hunger.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewIns()
        {
            DbClass db = new DbClass();
            var list = db.Institutions.ToList();
            return View(list);
        }
        public ActionResult ViewEmp()
        {
            DbClass db = new DbClass();
            var list = db.Employees.ToList();
            return View(list);
        }
    }
}