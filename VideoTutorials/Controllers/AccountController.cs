using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using VideoTutorials.Models;



namespace VideoTutorials.Controllers
{
    public class AccountController : Controller
    {
        private VideoTutorialsDbContext db = new VideoTutorialsDbContext();

        // GET: /Account/
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: /Account/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "UserID,FirstName,LastName,Email,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                user.DateRegistered = DateTime.Now;
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(user);
        }

       
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password, bool rememberMe = false)
        {
            var dbUser = db.Users
                .FirstOrDefault(x => x.Email == email && x.Password == password);
            var name = dbUser.FirstName;
            var username = dbUser.Email;
            var role = dbUser.Roles;
            if (dbUser != null)
            {
                FormsAuthentication.SetAuthCookie(name, rememberMe);
                if (role == "admin")
                {
                    return RedirectToAction("AdminIndex", "Home");
                }
                else
                {
                    return RedirectToAction("VideoList", "Videos");
                }
            }

            ViewBag.ErrorMessage = "Invalid user or password";
            return View();
        }
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        // GET: /Account/Edit/5
        public ActionResult Edit(int? id)
        {
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID, FirstName,LastName,Email,Password, Roles, DateOfBirth, FormalEducation, ProfesionalExperience, Courses, Skills")] User user)
        {
            if (ModelState.IsValid)
            {
                user.DateRegistered = DateTime.Now;
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: /Account/Edit/5
        public ActionResult EditProfile(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Edit");
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return ViewBag.ErrorMessage = "Invalid user or password";
            }
            else
                return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile([Bind(Include = "FirstName,LastName,Email,Password, DateOfBirth, FormalEducation, ProfesionalExperience, Courses, Skills")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Edit");
            }
            return View(user);
        }


       
        // GET: /Account/Details/5
       [Authorize(Roles = "admin")]
        public ActionResult Details(int? id)
        {
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
        [Authorize]
        public ActionResult UserDetails(int? id)
        {
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
        // GET: /Account/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
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

        // POST: /Account/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
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
