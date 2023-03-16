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
        public Institution() 
        {
            Collections = new List<Collection>();
        }
    }
}