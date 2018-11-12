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
    
    public class CampaignController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Campaign
        public ActionResult Index()
        {
            return View(db.Campaigns.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Campaign campaign)
        {
            if (ModelState.IsValid)
            {
                db.Campaigns.Add(campaign);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(campaign);
        }



        [HttpGet]
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Campaign campaign = db.Campaigns.Find(id);
            CampaignViewModel model = new CampaignViewModel
            {
                CampaignName = campaign.CampaignName,
                Category = campaign.Category,
                UsersSignedUp = campaign.UsersSignedUp
            };

            return View(model);
        }
        [HttpGet]
        [Authorize]
        public ActionResult Edit(int? id)
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
            //CampaignViewModel model = new CampaignViewModel
            //{
            //    CampaignName = campaign.CampaignName,
            //    Category = campaign.Category,
            //    UsersSignedUp = campaign.UsersSignedUp
            //};
            return View(campaign);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CampaignName, Categeory")]Campaign model)
        {
           
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);


        }
    }
}