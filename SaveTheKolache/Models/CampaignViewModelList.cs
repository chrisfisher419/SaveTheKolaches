using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaveTheKolache.Models
{
    public class CampaignViewModelList
    {
        public IEnumerable<SelectListItem> Campaigns { get; set; }
        public bool IsHidden { get; set; }
        public List<CampaignViewModel> CampaignViewModels { get; set; }
    }
}