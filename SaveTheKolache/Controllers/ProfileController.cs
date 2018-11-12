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
                LastName = profile.LastName,
                CellPhone = profile.CellPhone,
                BirthDate = profile.BirthDate,
                //Activity = profile.Activity
            };
            return View(model);

        }

        [HttpGet]
        public ActionResult Edit()
        {
            var user = User.Identity.Name;
            UserProfileInfo profile = db.UserProfileInfo.Where(x => x.Username == user).FirstOrDefault();

            ProfileViewModel model = new ProfileViewModel
            {
                Address = profile.Address,
                ZipCode = profile.ZipCode,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                CellPhone = profile.CellPhone,
                BirthDate = profile.BirthDate,
                //Activity = profile.Activity
            };
            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(/*[Bind(*//*Include = "UserID, FirstName,LastName, Address, ZipCode")]*/ ProfileViewModel model)
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
            var user = User.Identity.Name;
            UserProfileInfo profile = db.UserProfileInfo.Where(x => x.Username == user).FirstOrDefault();

            profile.Address = model.Address;
            profile.ZipCode = model.ZipCode;
            profile.FirstName = model.FirstName;
            profile.LastName = model.LastName;
            profile.CellPhone = model.CellPhone;
            profile.BirthDate = model.BirthDate;
            //profile.Activity = model.Activity;
        
            db.Entry(profile).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Details");


        }
    }
}