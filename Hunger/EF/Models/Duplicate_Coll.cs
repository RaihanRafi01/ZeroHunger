using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hunger.EF.Models
{
    public class Duplicate_Coll
    {
        public int Id { get; set; }
        [ForeignKey("Institution")]
        public int Ins_id { get; set; }
        public string FoodQty { get; set; }
        public DateTime ReqDate { get; set; }
        public DateTime ExpDate { get; set; }
        public string Status { get; set; }

        public virtual Institution Institution { get; set; }
    }
}