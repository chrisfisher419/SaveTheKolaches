using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SaveTheKolache.Models
{
    public class CampaignViewModel
    {
        [Display(Name = "Campaign Name")]
        public string CampaignName { get; set; }
        [Display(Name = "Type/Category")]
        public string Category { get; set; }
        [Display(Name = "Number Of People Signed")]
        public int UsersSignedUp { get; set; }
        [Display(Name = "Campaign Details")]
        public string CampaignDetails { get; set; }

        
    }
}