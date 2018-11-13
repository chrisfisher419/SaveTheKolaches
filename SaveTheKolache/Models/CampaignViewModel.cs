using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SaveTheKolache.Models
{
    public class CampaignViewModel
    {
        public int CampaignID { get; set; }
        [Display(Name = "Campaign Name")]
        public string CampaignName { get; set; }
        [Display(Name = "Type/Category")]
        public string Category { get; set; }
        [Display(Name = "Number Of People Signed")]
        public int UsersSignedUp { get; set; }
        [Display(Name = "Campaign Info")]
        public string CampaignInfo { get; set; }

        public IEnumerable<SignUpList> SignUpLists { get; set; }
        public SignUpList SignUpList { get; set; }

        
    }
}