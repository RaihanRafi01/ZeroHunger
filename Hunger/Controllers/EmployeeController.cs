using Hunger.Aut;
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
    [LogEmp]
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        
        // need to change here 
        public ActionResult DeliverView()
        {
            int id = (int)Session["EID"];
            DbClass db = new DbClass();
            var list = (from s in db.Deliver_Reqs
            where s.EmpAssign.Emp_id == id
            select s).ToList();
            //var list = db.Deliver_Reqs.Where(d => d.EmpAssign.Emp_id == id).ToList();
            ViewBag.count = list.Count;

            return View(list);
        }

        public ActionResult PerformDeliver(int id)
        {
            DbClass db = new DbClass();
            Deliver_Req req = new Deliver_Req();
            EmpAssign empAssign = new EmpAssign();
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

                                // change status to deliverd in assing employee list

            var emp = (from s in db.EmpAssigns
                     where s.Id == d.Employee_Assign_id
                       select s).SingleOrDefault();
            empAssign.Id= emp.Id;
            empAssign.Col_id = emp.Col_id;
            empAssign.Emp_id = emp.Emp_id;
            empAssign.AssignDate = emp.AssignDate;
            empAssign.Status = "Deliverd";
            db.Entry(emp).CurrentValues.SetValues(empAssign);
            
            db.SaveChanges();

            return RedirectToAction("DeliverView");

        }

    }
}