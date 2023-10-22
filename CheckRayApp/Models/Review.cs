using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckRayApp.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public virtual User User{ get; set; }
    }
}