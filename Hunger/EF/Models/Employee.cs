using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hunger.EF.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }

        public virtual ICollection<EmpAssign> EmpAssigns { get; set; }
        public Employee()
        {
            EmpAssigns = new List<EmpAssign>();

        }

    }
}