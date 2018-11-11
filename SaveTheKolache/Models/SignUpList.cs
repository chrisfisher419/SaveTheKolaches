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
        [Display(Name="Campaign")]
        public int CampaignID { get; set; }
        public string CampaignName { get; set; }
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime DateSigned
        {
            get { return System.DateTime.Now; }
            set { DateSigned = value; }
        }

        public virtual UserProfileInfo UserProfileInfo { get; set; }
        public virtual Campaign Campaign { get; set; }
    }
}