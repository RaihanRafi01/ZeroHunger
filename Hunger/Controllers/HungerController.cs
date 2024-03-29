﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hunger.EF;
using Hunger.EF.Models;
using Hunger.Models;
using Microsoft.Ajax.Utilities;

namespace Hunger.Controllers
{

    public class HungerController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            
            if (ModelState.IsValid)
            {
                if (login.Name.Equals("admin") && login.Password.Equals("123"))
                {
                    Session["Admin"] = "admin";
                    var retUrl = Request["ReturnUrl"];
                    if (retUrl != null)
                    {
                        return Redirect(retUrl);
                    }
                    return RedirectToAction("Index", "Admin");
                }

                DbClass db = new DbClass();
                var user = (from u in db.Institutions
                            where u.Name.Equals(login.Name)
                            && u.Password.Equals(login.Password)
                            select u).SingleOrDefault();

                var userE = (from u in db.Employees
                            where u.Name.Equals(login.Name)
                            && u.Password.Equals(login.Password)
                            select u).SingleOrDefault();
                // 
                if (user != null)
                {
                    Session["UID"] = user.Id;
                    Session["UN"] = user.Name;

                    var retUrl = Request["ReturnUrl"];
                    if (retUrl != null)
                    {
                        return Redirect(retUrl);
                    }

                    return RedirectToAction("Index", "Ins");
                }
                if (userE != null)
                {
                    Session["EID"] = userE.Id;
                    Session["EN"] = userE.Name;

                    var retUrl = Request["ReturnUrl"];
                    if (retUrl != null)
                    {
                        return Redirect(retUrl);
                    }

                    return RedirectToAction("Index", "Employee");
                }
            }

            TempData["Msg"] = "Username Password invalid";
            return View(login);

        }

        [HttpGet]
        public ActionResult Reg()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Reg(RegModel reg)
        {
            DbClass db = new DbClass();
            Employee emp = new Employee();
            Institution ins = new Institution();
            var Role = reg.Role;
            if (Role == "emp") 
            {
                emp.Name = reg.Name;
                emp.Password = reg.Password;
                emp.Email = reg.Email;
                emp.Contact = reg.Contact;
                db.Employees.Add(emp);
                db.SaveChanges();
            }
            if (Role == "ins") 
            {
                ins.Name = reg.Name;
                ins.Password = reg.Password;
                db.Institutions.Add(ins);
                db.SaveChanges();
            }
            return RedirectToAction("Login");
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}