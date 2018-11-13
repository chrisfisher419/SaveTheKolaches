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
        [HttpGet]
        public ActionResult Index()
        {
            var model = new CampaignViewModelList();
            model.IsHidden = true;
           var list = db.Campaigns.ToList();
            model.CampaignViewModels = new List<CampaignViewModel>();
            Session["Campaigns"] =  from category in list
                select new SelectListItem()
                {
                    Text = category.CampaignName,
                    Value = category.CampaignID.ToString()
                };
            model.Campaigns = (IEnumerable<SelectListItem>) Session["Campaigns"];

            foreach (var item in list)
            {
               
               
                    model.CampaignViewModels.Add(new CampaignViewModel
                    {
                        CampaignID = item.CampaignID,
                        CampaignInfo = item.CampaignInfo,
                        CampaignName = item.CampaignName,
                        Category = item.Category,
                        UsersSignedUp = item.UsersSignedUp
                    });
            }
            foreach (var item in model.CampaignViewModels )
                {
                    item.SignUpLists = db.SignnUpList.Where(x => x.CampaignID == item.CampaignID);

                }
            return View(model);

            //return View(db.Campaigns.ToList());
        }

        [HttpPost]
        public ActionResult Index(int? campaignID)
        {
            var model = new CampaignViewModelList();
            model.IsHidden = false;
            var list = db.Campaigns.Find(campaignID);
            model.CampaignViewModels = new List<CampaignViewModel>();
            model.Campaigns = (IEnumerable<SelectListItem>)Session["Campaigns"];

            

                model.CampaignViewModels.Add(new CampaignViewModel
                {
                    CampaignID = list.CampaignID,
                    CampaignInfo = list.CampaignInfo,
                    CampaignName = list.CampaignName,
                    Category = list.Category,
                    UsersSignedUp = list.UsersSignedUp
                });
            
            foreach (var item in model.CampaignViewModels)
            {
                item.SignUpLists = db.SignnUpList.Where(x => x.CampaignID == item.CampaignID);

            }
            return View(model);

            //return View(db.Campaigns.ToList());
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
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
            int campaignID = campaign.CampaignID;
            CampaignViewModel model = new CampaignViewModel
            {
                CampaignName = campaign.CampaignName,
                Category = campaign.Category,
                UsersSignedUp = campaign.UsersSignedUp,
                CampaignInfo = campaign.CampaignInfo,
                SignUpList = new SignUpList
                {
                    CampaignID = campaignID
                }

            };
      


            return View(model);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(CampaignViewModel viewModel, int? id)
        {
            Campaign campaign = db.Campaigns.Where(x => x.CampaignID == id).FirstOrDefault();


            campaign.CampaignInfo = viewModel.CampaignInfo;
            campaign.CampaignName = viewModel.CampaignName;
            campaign.Category = viewModel.Category;
            if (ModelState.IsValid)
            {
                db.Entry(campaign).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(campaign);


        }

        //public ActionResult Search(string sortOrder, string searchString)
        //{

        //    var entries = from e in db.Campaigns
        //        join sl in db.SignnUpList on e.CampaignID equals sl.CampaignID
        //        select new {e.CampaignName, e.CampaignInfo, e.UsersSignedUp, sl.FirstName, sl.LastName};
            
  
        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        entries = entries.Where(e => e.CampaignName.Contains(searchString);
        //        list = list.Where(s )

        //    }
        //}
    }
}