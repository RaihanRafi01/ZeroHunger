using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hunger.EF.Models
{
    public class Institution
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Collection> Collections { get; set; }
        public virtual ICollection<Duplicate_Coll> Duplicate_Colls { get; set; }
        public Institution() 
        {
            Duplicate_Colls = new HashSet<Duplicate_Coll>();
            Collections = new List<Collection>();
        }
    }
}