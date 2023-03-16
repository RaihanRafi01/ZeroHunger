using Hunger.EF;
using Hunger.EF.Models;
using Hunger.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Data.Entity.Infrastructure.Design.Executor;

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
        public ActionResult ViewReq()
        {
            DbClass db = new DbClass();
            var list = db.Collections.ToList();
            return View(list);
        }

       
        public ActionResult AssignEmp(int id)
        {
            DbClass db = new DbClass();
            Collection c = new Collection();
            EmpAssign a = new EmpAssign();
            int CountEmp = db.Employees.Count();
            Random random= new Random();
            var ed = (from s in db.Collections
                      where s.Id == id
                      select s).SingleOrDefault();
            
            c.Id = ed.Id;
            c.Ins_id = ed.Ins_id;
            c.FoodQty = ed.FoodQty;
            c.ReqDate= ed.ReqDate;
            c.ExpDate = ed.ExpDate;
            c.Status = "Assigned";
            db.Entry(ed).CurrentValues.SetValues(c);
            a.Col_id = 1;
            a.Emp_id = random.Next(1, CountEmp);
            a.Status= "Assigned";
            a.AssignDate = DateTime.Now;
            db.EmpAssigns.Add(a);
            db.SaveChanges();
            return RedirectToAction("ViewReq");
        }
        

    }
}