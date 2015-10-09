using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FindLecturerApplication.Models;

namespace FindLecturerApplication.Controllers
{
    public class UserProfilesController : Controller
    {
        private FindLecturerApplicationContext db = new FindLecturerApplicationContext();

        // GET: UserProfiles
        public ActionResult LecturersList()
        {
            return View(db.UserProfiles.ToList());
        }

        // GET: UserProfiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProfile userProfile = db.UserProfiles.Find(id);
            if (userProfile == null)
            {
                return HttpNotFound();
            }
            return View(userProfile);
        }

        // GET: UserProfiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserProfiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProfileID,BirthDate,FormalEducation,ProfesionalExperience,Skills,UserImage")] UserProfile userProfile)
        {
            if (ModelState.IsValid)
            {
                db.UserProfiles.Add(userProfile);
                db.SaveChanges();
                return RedirectToAction("LecturersList");
            }

            return View(userProfile);


            //HttpPostedFileBase[] files


            //if (ModelState.IsValid)
            //{
            //    if (files != null && files[0] != null)
            //    {
            //        FilesSaving fileSaving = new FilesSaving();
            //        foreach (HttpPostedFileBase file in files)
            //        {
            //            if (file.ContentLength < 512000)
            //            {
            //                bool isValidImg = fileSaving.IsValidImage(file);
            //                if (isValidImg == false)
            //                {
            //                    ViewBag.ProfileID = db.Users.ToList();

            //                    ModelState.AddModelError("Photo", "Nevaliden tip");
            //                    return View(userProfile);
            //                }
            //                string path = "~/Images/UserPictures/";
            //                bool isSaved = fileSaving.FileImageSaving(path, file);
            //                if (isSaved == true)
            //                {
            //                    UserProfilePicture picture = new UserProfilePicture();
            //                    picture.ImageUrl = (path + file.FileName).ToString();
            //                }
            //            }
            //            else
            //            {

            //                ModelState.AddModelError("Photo", "Сликата мора да биде помала од 500KB");
            //                return View(userProfile);
            //            }
            //        }
            //    }
            //    //       else
            //    //    {
            //    //        UserProfilePicture picture = new UserProfilePicture();
            //    //        picture.ImageUrl = ("~/Images/UserPictures/" + "noImage.jpg").ToString();
            //    //        db.UserProfilePicture.Add(picture);
            //    //    }
            //    //    db.UserProfilePictures.Add(picture);
            //    //    db.SaveChanges();
            //    //    return RedirectToAction("Index");
            //    //}
            // GET: UserProfiles/Edit/5
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProfile userProfile = db.UserProfiles.Find(id);
            if (userProfile == null)
            {
                return HttpNotFound();
            }
            return View(userProfile);
        }

        // POST: UserProfiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProfileID,BirthDate,FormalEducation,ProfesionalExperience,Skills,UserImage")] UserProfile userProfile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userProfile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("LecturersList");
            }
            return View(userProfile);
        }

        // GET: UserProfiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProfile userProfile = db.UserProfiles.Find(id);
            if (userProfile == null)
            {
                return HttpNotFound();
            }
            return View(userProfile);
        }

        // POST: UserProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserProfile userProfile = db.UserProfiles.Find(id);
            db.UserProfiles.Remove(userProfile);
            db.SaveChanges();
            return RedirectToAction("LecturersList");
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
