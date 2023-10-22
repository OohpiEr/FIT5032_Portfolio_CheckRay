using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CheckRay.Context;
using CheckRayApp.Migrations;
using CheckRayApp.Models;
using Microsoft.AspNet.Identity;

namespace CheckRayApp.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private CheckRayAppContext db = new CheckRayAppContext();
        private User currentUser  = null;

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

        private bool CheckAdminRole(bool redirect)
        {
            User user = GetCurrentUser();

            if (!user.isAdmin())
            {
                if (redirect)
                {
                    Response.Redirect("home", false);
                }
                return false;
            }

            return true;

        }

        // GET: Users
        [Authorize]
        public ActionResult Index()
        {
            CheckAdminRole(true);

            //System.Diagnostics.Debug.WriteLine(user.Email);

            //return View(users);
            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            CheckAdminRole(true);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            CheckAdminRole(true);

            ViewBag.Email = User.Identity.GetUserName();

            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName")] User user)
        {
            CheckAdminRole(true);

            // eFolio 7
            user.UserId = User.Identity.GetUserId();
            user.Email = User.Identity.GetUserName();
            user.UserRole = (int) CheckRayApp.Models.User.Role.PATIENT;

            ModelState.Clear();
            TryValidateModel(user);

            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User currentUser = GetCurrentUser();
            if (!CheckAdminRole(false) && currentUser.Id != id)
            {
                Response.Redirect("home", false);
            }

            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,FirstName,LastName,UserRole")] User user)
        {
            User currentUser = GetCurrentUser();

            //if admin
            if (CheckAdminRole(false))
            {
                //user.UserId = User.Identity.GetUserId();
                if (ModelState.IsValid)
                {
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    //return RedirectToAction("Index");
                }
                return View(user);
            }

            //User userToUpdate = user;
            //if not admin and not editing current user
            if (currentUser.Id != user.Id)
            {
                Response.Redirect("home", false);
            }

            //if not admin but is editing current user
            //cannot change role
            //user.UserRole = currentUser.UserRole;
            currentUser.Email = user.Email;
            currentUser.FirstName = user.FirstName;
            currentUser.LastName= user.LastName;
            //userToUpdate = currentUser;
            if (ModelState.IsValid)
            {
                db.Entry(currentUser).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
                return View(user);
            }

            
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            CheckAdminRole(true);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CheckAdminRole(true);

            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
