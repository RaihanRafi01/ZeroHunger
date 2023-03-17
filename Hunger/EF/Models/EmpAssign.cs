using Hunger.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hunger.EF.Models
{
    public class EmpAssign
    {
        public int Id { get; set; }
        [ForeignKey("Collection")]
        public int Col_id { get; set; }
        [ForeignKey("Employee")]
        public int Emp_id { get; set; }
        public DateTime AssignDate { get; set; }
        public string Status { get; set; }



        public virtual Collection Collection { get; set; }
        public virtual Employee Employee { get; set; }

        public virtual ICollection<Deliver> Delivers { get; set; }
        public EmpAssign()
        {
            Delivers = new List<Deliver>();

        }
    }
}