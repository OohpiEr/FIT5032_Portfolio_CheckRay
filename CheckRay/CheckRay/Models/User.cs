using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckRay.Models
{
    public class User
    {
        public int Id { get; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Role { get; set; }

        enum Role : int
        {
            ADMIN = 1,
            PATIENT = 2,
            DOCTOR = 3
        }

    }
    
}