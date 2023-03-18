﻿using Hunger.EF;
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
        public ActionResult Index()
        {
           //int id = (int)Session["UID"];
            
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
            Duplicate_Coll a = new Duplicate_Coll();
            int id = (int)Session["UID"];
            c.Ins_id = id;
            c.FoodQty = coll.FoodQty;
            c.ReqDate = DateTime.Now;
            c.ExpDate = coll.ExpDate;
            c.Status= "Pending";
            db.Collections.Add(c);
            a.Ins_id = id;
            a.FoodQty = coll.FoodQty;
            a.ReqDate = DateTime.Now;
            a.ExpDate = coll.ExpDate;
            a.Status = "Pending";
            db.duplicate_Colls.Add(a);
            db.SaveChanges();
            return View();
        }
        public ActionResult ColReqView()
        {
            DbClass db = new DbClass();
            var list = db.duplicate_Colls.ToList();
            return View(list);
        }
    }
}