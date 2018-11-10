using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SaveTheKolache.Models
{
    public class Campaign
    {
        [Key]
        public int CampaignID { get; set; }
        public string CampaignName { get; set; }
        public string Category { get; set; }
        public int UsersSignedUp { get; set; }
    }
}