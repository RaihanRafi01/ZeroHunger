using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hunger.Models
{
    public class RegModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Role { get; set; }
    }
}