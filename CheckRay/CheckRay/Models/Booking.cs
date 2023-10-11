using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CheckRay.Models
{
    public class Booking
    {
        public int id { get; set; }
        public DateTime datetime { get; set; }
        public virtual Facility facility { get; set; }
        public virtual User patient { get; set; }
        public virtual User doctor { get; set; }
        public bool status { get; set; }
        public ICollection<string> images{ get; set; }
        //public int reviewId { get; set; }
        public virtual Review review { get; set; }
    }
}