using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SaveTheKolache.Models
{
    public class SignUpList
    {
        [Key]
        public int SignID { get; set; }
        public int CampaignID { get; set; }
        public string CampaignName { get; set; }
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateSigned { get; set; }
    }
}