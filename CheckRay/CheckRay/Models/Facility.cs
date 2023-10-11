using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckRay.Models
{
    public class Facility
    {
        public int facilityId { get; set; }
        public string facilityName { get; set; }
        public string facilityAddress { get; set; }

        //public virtual ICollection<Booking> Bookings { get; set; }

    }
}