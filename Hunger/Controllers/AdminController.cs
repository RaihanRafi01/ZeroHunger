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
            DeliverReq deliver = new DeliverReq();

            int CountEmp = db.Employees.Count();

            Random random= new Random();
            var col = (from s in db.Collections
                      where s.Id == id
                      select s).SingleOrDefault();
            

            // adding a random employ to assign delever
            int randomId = random.Next(1, CountEmp);

            var emp = (from s in db.Employees
                      where s.Id == randomId
                       select s).SingleOrDefault();
            a.Col_id = col.Id;
            a.Emp_id = emp.Id;
            a.Status= "Assigned";
            a.AssignDate = DateTime.Now;
            db.EmpAssigns.Add(a);
            db.SaveChanges();

            // Add deleverReq from collection
            deliver.EmpAss_id= emp.Id;
            deliver.Name = emp.Name;
            deliver.ResName = col.Institution.Name;
            deliver.FoodQty = col.FoodQty;
            deliver.ExpDate= col.ExpDate;
            deliver.AssingDate = DateTime.Now;
            deliver.Status = "Ready for Deliver";
            db.DeliverReqs.Add(deliver);
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