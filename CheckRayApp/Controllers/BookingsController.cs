using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using CheckRay.Context;
using CheckRayApp.Models;
using Microsoft.AspNet.Identity;

namespace CheckRayApp.Controllers
{
    public class BookingsController : Controller
    {
        private CheckRayAppContext db = new CheckRayAppContext();
        private User currentUser = null;

        private User GetCurrentUser()
        {
            if (currentUser == null)
            {
                string userId = User.Identity.GetUserId();
                User user = db.Users.Where(u => u.UserId == userId).ToList().First();
                currentUser = user;
            }

            return currentUser;
        }

        // GET: Bookings
        public ActionResult Index()
        {
            return View(db.Bookings.ToList());
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {
            List<SelectListItem>  facilities = db.Facilities.Select(f => new SelectListItem
            {
                Text = f.FacilityName,
                Value = f.FacilityId.ToString()
            }).ToList();
            ViewBag.Facilities = facilities;

            List<SelectListItem> doctors = db.Users
                    .Where(p => p.UserRole == (int)CheckRayApp.Models.User.Role.DOCTOR)
                    .Select(p => new SelectListItem
                    {
                        Text = p.FirstName + " " + p.LastName,
                        Value = p.Id.ToString()
                    }).ToList();
            ViewBag.Doctors = doctors;

            ViewBag.isPatient = false;
            User currentUser = GetCurrentUser();
            if (currentUser.isPatient())
            {
                ViewBag.isPatient = true;
            } else
            {
                List<SelectListItem> patients = db.Users
                    .Where(p => p.UserRole == (int) CheckRayApp.Models.User.Role.PATIENT)
                    .Select(p => new SelectListItem
                    {
                        Text = p.FirstName + " " + p.LastName,
                        Value = p.Id.ToString()
                    }).ToList();
                ViewBag.Patients = patients;
            }

            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Datetime,Status")] Booking booking, string Facilities, string Doctors, string Patients = null)
        {
            try
            {
                //System.Diagnostics.Debug.WriteLine(Facilities);
                booking.Facility = db.Facilities.Find(Int32.Parse(Facilities));
                booking.Doctor= db.Users.Find(Int32.Parse(Doctors));

                User currentUser = GetCurrentUser();
                if (currentUser.isPatient())
                {
                    booking.Patient = currentUser;
                } else
                {
                    booking.Patient = db.Users.Find(Int32.Parse(Patients));
                }
            } catch
            {
                return HttpNotFound();
            }

            


            if (ModelState.IsValid)
            {
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(booking);
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Datetime,Status")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
