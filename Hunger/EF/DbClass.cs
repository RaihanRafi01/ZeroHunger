using Hunger.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hunger.EF
{
    public class DbClass : DbContext
    {
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}