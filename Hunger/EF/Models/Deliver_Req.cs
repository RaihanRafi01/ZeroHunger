using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hunger.EF.Models
{
    public class Deliver_Req
    {
        public int Id { get; set; }

        [ForeignKey("EmpAssign")]
        public int Employee_Assign_id { get; set; }
        public string Name { get; set; }

        public string Resturant_Name { get; set; }

        public string Food_Quality { get; set; }

        public DateTime Expire_Date { get; set; }
        public DateTime Assing_Date { get; set; }
        public string Status_Delivery { get; set; }
        public virtual EmpAssign EmpAssign { get; set; }
    }
}