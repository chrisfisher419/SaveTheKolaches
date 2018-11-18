using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SaveTheKolache.Models;

namespace SaveTheKolache.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Profile
        public ActionResult Details()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Login", "Campaign");
            }
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
                Activity = profile.Activity,
                EmailAddress = profile.EmailAddress
            };
            return View(model);

        }

        [HttpGet]
        public ActionResult Edit()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Login", "Campaign");
            }
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
                Activity = profile.Activity,
                EmailAddress = profile.EmailAddress
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
            profile.Activity = model.Activity;
            profile.EmailAddress = model.EmailAddress;


            //var roleStore = new RoleStore<IdentityRole>(db);
            //var roleManager = new RoleManager<IdentityRole>(roleStore);

            //var userStore = new UserStore<ApplicationUser>(db);
            //var userManager = new UserManager<ApplicationUser>(userStore);

            //if (profile.Activity == false)
            //{
            //    UserManager.AddToRole(, "Inactive");
            //}


            db.Entry(profile).State = EntityState.Modified;
            db.SaveChanges();
            if (profile.Activity == false)
            {

                return View("Lockout");
            }
            return RedirectToAction("Details");


        }

     
    }
}