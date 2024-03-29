﻿using Hunger.Aut;
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
    [LogAdmin]
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
            var lis = list.OrderByDescending(d => d.Id);
            return View(lis);
        }

       
        public ActionResult AssignEmp(int id)
        {
            // click a link to execute these 
            DbClass db = new DbClass();
            Collection c = new Collection();
            EmpAssign a = new EmpAssign();
            Deliver_Req deliver = new Deliver_Req();

            int CountEmp = db.Employees.Count();

            Random random= new Random();
            var col = (from s in db.Collections
                      where s.Id == id
                      select s).SingleOrDefault();
            c.Id = col.Id;
            c.Ins_id = col.Ins_id;
            c.FoodQty = col.FoodQty;
            c.ReqDate = col.ReqDate;
            c.ExpDate = col.ExpDate;
            c.Status = "Collected";
            db.Entry(col).CurrentValues.SetValues(c);
            db.SaveChanges();

            // adding a random employ to assign delever
            int randomId = random.Next(1, CountEmp);

            var emp = (from s in db.Employees
                      where s.Id == randomId
                       select s).SingleOrDefault();
            a.Col_id = col.Id;
            a.Emp_id = emp.Id;
            a.Status= "Collected";
            a.AssignDate = DateTime.Now;
            db.EmpAssigns.Add(a);
            db.SaveChanges();

            // Add deleverReq from collection
            
            deliver.Employee_Assign_id = a.Id;
            deliver.Name = emp.Name;
            deliver.Resturant_Name = col.Institution.Name;
            deliver.Food_Quality = col.FoodQty;
            deliver.Expire_Date = col.ExpDate;
            deliver.Assing_Date = DateTime.Now;
            deliver.Status_Delivery = "Ready for Deliver";
            
            db.Deliver_Reqs.Add(deliver);
            db.SaveChanges();
            // remove not working properly 
            //db.Collections.Remove(col);
           // db.SaveChanges();
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