using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IdentitySample.Models;
using SaveTheKolache.Models;

namespace SaveTheKolache.Controllers
{
    [Authorize]
    public class SignUpListController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: SignUpList
        [HttpGet]
        public ActionResult AlreadySigned()
        {
            return View();
        }

        public ActionResult Sign(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Campaign campaign = db.Campaigns.Find(id);
            if (campaign == null)
            {
                return HttpNotFound();
            }

            return View(campaign);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Sign(Campaign campaign, int? id)
        {
            campaign = db.Campaigns.Find(id);
            //Campaign campaign = db.Campaigns.Where()
            CampaignSignViewModel viewModel = new CampaignSignViewModel();
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
            SignUpList list = new SignUpList();
            list.FirstName = profile.FirstName;
            list.LastName = profile.LastName;
            list.UserID = profile.UserID;
            list.CampaignID = campaign.CampaignID;
            list.CampaignName = campaign.CampaignName;
            //list.DateSigned = System.DateTime.Now;


            foreach (var item in db.SignnUpList)
                if (list.UserID == item.UserID && list.CampaignID == item.CampaignID)
                {
                    return RedirectToAction("AlreadySigned", "SignUpList");
                }

            //if (db.SignnUpList.Any((o => o.UserID == list.UserID)))
            //{
            //    if (db.SignnUpList(o => o.CampaignID == list.CampaignID))
            //    {
            //        return RedirectToAction("AlreadySigned", "SignUpList");
            //    }
            //}

            campaign.UsersSignedUp = campaign.UsersSignedUp + 1;
            //campaign.UsersSignedUp++;

            //var item = from n in db.Campaigns
            //    where n.CampaignID == Int32.Parse(Request.QueryString["CampaignID"])
            //    select n;
            //item.UsersSignedUp +=

            //db.Entry(campaign).State = EntityState.Modified;
            //db.SaveChanges();
            db.SignnUpList.Add(list);
            db.SaveChanges();
            return RedirectToAction("Index", "Campaign");
        }

        //public ActionResult Create()
        //{

        //    return View();
        //}

        //POST: Courses/Create
        //To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Campaign)] SignUpList list)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Courses.Add(course);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName", course.SubjectID);
        //    return View(course);
        //}
    }
}