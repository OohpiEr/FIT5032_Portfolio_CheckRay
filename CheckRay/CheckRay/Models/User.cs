using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckRay.Models
{
    public class User
    {
        public int id { get; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int role { get; set; }

        enum Role : int
        {
            ADMIN = 1,
            PATIENT = 2,
            DOCTOR = 3
        }

    }
    
}