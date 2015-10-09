using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FindLecturerApplication.Models;
using System.Web.Security;

namespace FindLecturerApplication.Controllers
{
    public class AccountController : Controller
    {
        private FindLecturerApplicationContext db = new FindLecturerApplicationContext();

        // GET: Account
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Account/Details/5
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

        // GET: Account/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: Account/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "ID,FirstName,LastName,Email,Password,ConfirmPassword,DateRegistered,Roles,isApproved")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
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
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    return RedirectToAction("LecturersList", "UserProfiles");
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

        // GET: Account/Edit/5
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

        // POST: Account/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,Email,Password,ConfirmPassword,DateRegistered,Roles,isApproved")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Account/Delete/5
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

        // POST: Account/Delete/5
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

        [Authorize(Roles = "admin")]
        public ActionResult usersList(string username)
        {
            var users = db.Users.Include(v => v.Email).Where(v => v.isApproved == false);

            if (!string.IsNullOrWhiteSpace(username))
            {
                var filteredResult =
                    db.Users
                    .Where(x =>
                                x.Email.Contains(username)
                            )
                    .ToList();

                return View(filteredResult);
            }
            return View(users.ToList());
        }
        public ActionResult ViewProfile(int? id)
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

        [HttpGet]
        // GET: /Videos/
        [Authorize(Roles = "admin")]
        public ActionResult UnapprovedUsers()
        {
            var users = db.Users.Include(v => v.Email).Where(v => v.isApproved == true);


            return View(users.ToList());
        }
        [Authorize(Roles = "admin")]
        public ActionResult ApproveUser(int? id)
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
            user.isApproved = true;
            db.SaveChanges();

            return RedirectToAction("UnapprovedUsers", "Account");
        }
    }
}
