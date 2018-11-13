using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace SaveTheKolache.Models
{
    public class CampaignSignViewModel
    {
        public int CampaignID { get; set; }
        public string CampaignName { get; set; }
        public IList<UserLoginInfo> UserLoginInfo { get; set; }
        public IEnumerable<UserProfileInfo> UserProfileInfo { get; set; }
        public IEnumerable<CampaignViewModel> CampaignsViewModels { get; set; }
    }
}