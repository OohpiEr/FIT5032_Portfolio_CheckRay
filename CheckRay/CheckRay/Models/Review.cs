using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckRay.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public virtual User User{ get; set; }
        //public int patientId { get; set; }
        //public virtual ICollection<Booking> Bookings { get; set; }
    }
}