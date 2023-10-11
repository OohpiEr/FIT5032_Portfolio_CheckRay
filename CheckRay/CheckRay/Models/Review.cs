using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckRay.Models
{
    public class Review
    {
        public int id { get; set; }
        public int rating { get; set; }
        public string comment { get; set; }
        public virtual User user{ get; set; }
        //public int patientId { get; set; }
        //public virtual ICollection<Booking> Bookings { get; set; }
    }
}