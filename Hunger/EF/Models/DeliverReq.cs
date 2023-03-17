﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hunger.EF.Models
{
    public class DeliverReq
    {
        public int Id { get; set; }

        [ForeignKey("EmpAssign")]
        public int EmpAss_id { get; set; }
        public string Name { get; set; }

        public string ResName { get; set; }

        public string FoodQty { get; set; }

        public DateTime ExpDate { get; set; }
        public DateTime AssingDate { get; set; }
        public string Status { get; set; }
        public virtual EmpAssign EmpAssign { get; set; }

    }
}