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
            // click a link to execute these 
            DbClass db = new DbClass();
            Collection c = new Collection();
            EmpAssign a = new EmpAssign();
            Deliver deliver = new Deliver();

            int CountEmp = db.Employees.Count();
            Random random= new Random();
            var col = (from s in db.Collections
                      where s.Id == id
                      select s).SingleOrDefault();
            
            c.Id = col.Id;
            c.Ins_id = col.Ins_id;
            c.FoodQty = col.FoodQty;
            c.ReqDate= col.ReqDate;
            c.ExpDate = col.ExpDate;
            c.Status = "Assigned";
            db.Entry(col).CurrentValues.SetValues(c);
            db.SaveChanges();

            int randomId = random.Next(1, CountEmp);
            var emp = (from s in db.Employees
                      where s.Id == randomId
                       select s).SingleOrDefault();
            a.Col_id = c.Id;
            a.Emp_id = emp.Id;
            a.Status= "Assigned";
            a.AssignDate = DateTime.Now;
            db.EmpAssigns.Add(a);
            db.SaveChanges();

            deliver.EmpAss_id= emp.Id;
            deliver.Name = emp.Name;
            deliver.DeliveryDate = DateTime.Now;
            deliver.Status = "Ready for Deliver";
            db.Delivers.Add(deliver);
            db.SaveChanges();
            return RedirectToAction("ViewReq");
        }
        public ActionResult ViewAssEmp()
        {
            DbClass db = new DbClass();
            var list = db.EmpAssigns.ToList();
            return View(list);
        }

    }
}