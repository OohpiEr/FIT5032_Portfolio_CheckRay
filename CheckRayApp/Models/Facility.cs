using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckRayApp.Models
{
    public class Facility
    {
        public int FacilityId { get; set; }
        public string FacilityName { get; set; }
        public string FacilityAddress { get; set; }

        //public virtual ICollection<Booking> Bookings { get; set; }

    }
}