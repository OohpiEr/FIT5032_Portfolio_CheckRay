using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CheckRayApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserRole { get; set; }
        public string UserId { get; set; }
        //public SelectList UserRoles { get; set; }
        public bool isAdmin()
        {
            return this.UserRole.Equals((int) Role.ADMIN);
        }
        public bool isDoctor()
        {
            return this.UserRole.Equals((int)Role.DOCTOR);
        }
        public bool isPatient()
        {
            return this.UserRole.Equals((int)Role.PATIENT);
        }
        public string GetUserRoleString()
        {
            Role userRole = (Role) this.UserRole;

            return userRole.ToString();
        }
        public enum Role : int
        {
            ADMIN = 1,
            PATIENT = 2,
            DOCTOR = 3
        }

    }
    
}