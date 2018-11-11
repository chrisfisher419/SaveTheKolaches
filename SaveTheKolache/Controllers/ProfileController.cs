using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using SaveTheKolache.Models;

namespace SaveTheKolache.Controllers
{
    public class ProfileController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Profile
        public ActionResult Details()
        {
            var user = User.Identity.Name;
            UserProfileInfo profile = db.UserProfileInfo.Where(x => x.Username == user).FirstOrDefault();
            
            ProfileViewModel model = new ProfileViewModel
            {
                Address = profile.Address,
                ZipCode = profile.ZipCode,
                FirstName = profile.FirstName,
                LastName = profile.LastName
            };
            return View(model);

        }

        public ActionResult Edit()
        {
            var user = User.Identity.Name;
            UserProfileInfo profile = db.UserProfileInfo.Where(x => x.Username == user).FirstOrDefault();

            ProfileViewModel model = new ProfileViewModel
            {
                Address = profile.Address,
                ZipCode = profile.ZipCode,
                FirstName = profile.FirstName,
                LastName = profile.LastName
            };
            return View(model);

        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "UserID, FirstName,LastName, Address, ZipCode")] UserProfileInfo userProfileInfo)
        {
            //var user = User.Identity.Name;
            //UserProfileInfo profile = db.UserProfileInfo.Where(x => x.Username == user).FirstOrDefault();
            //ProfileViewModel model = new ProfileViewModel
            //{
            //    Address = profile.Address,
            //    ZipCode = profile.ZipCode,
            //    FirstName = profile.FirstName,
            //    LastName = profile.LastName
            //};
            db.Entry(userProfileInfo).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}