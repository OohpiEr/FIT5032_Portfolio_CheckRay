using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CheckRayApp.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime Datetime { get; set; }
        public virtual Facility Facility { get; set; }
        public virtual User Patient { get; set; }
        public virtual User Doctor { get; set; }
        public bool Status { get; set; }
        public ICollection<string> Images{ get; set; }
        public virtual Review Review { get; set; }

        public string GetStatusString()
        {
            string statusStr = "Incomplete";

            if (this.Status) {
                statusStr = "Complete";
            }

            return statusStr;
        }
    }

    
    
}