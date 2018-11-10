using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SaveTheKolache.DAL;
using SaveTheKolache.Models;

namespace SaveTheKolache.Controllers
{
    [Authorize]
    public class UserProfileInfoesController : Controller
    {
        private EFDbContext db = new EFDbContext();

        // GET: UserProfileInfoes
        public ActionResult Index()
        {
            return View(db.UserProfileInfos.ToList());
            //  UserProfileInfo model = db.UserProfileInfos.Find(id);

            ////  return View(db.UserProfileInfos.ToList());
            //  return View(model);
        }

        // GET: UserProfileInfoes/Details/5
        public ActionResult Details(string userId)
        {
            userId = User.Identity.GetUserId();

            if (userId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProfileInfo userProfileInfo = db.UserProfileInfos.Find(userId);
            if (userProfileInfo == null)
            {
                return HttpNotFound();
            }
            return View(userProfileInfo);
        }

        // GET: UserProfileInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserProfileInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,Password,Username,CreateDate,BirthDate,FirstName,LastName,Address,ZipCode,EmailAddress,CellPhone")] UserProfileInfo userProfileInfo)
        {
            if (ModelState.IsValid)
            {
                db.UserProfileInfos.Add(userProfileInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userProfileInfo);
        }

        // GET: UserProfileInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProfileInfo userProfileInfo = db.UserProfileInfos.Find(id);
            if (userProfileInfo == null)
            {
                return HttpNotFound();
            }
            return View(userProfileInfo);
        }

        // POST: UserProfileInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Password,Username,CreateDate,BirthDate,FirstName,LastName,Address,ZipCode,EmailAddress,CellPhone")] UserProfileInfo userProfileInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userProfileInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userProfileInfo);
        }

        // GET: UserProfileInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProfileInfo userProfileInfo = db.UserProfileInfos.Find(id);
            if (userProfileInfo == null)
            {
                return HttpNotFound();
            }
            return View(userProfileInfo);
        }

        // POST: UserProfileInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserProfileInfo userProfileInfo = db.UserProfileInfos.Find(id);
            db.UserProfileInfos.Remove(userProfileInfo);
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
