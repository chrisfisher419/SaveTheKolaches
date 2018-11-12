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
        [Display(Name = "Campaign Name")]
        public string CampaignName { get; set; }
        [Display(Name = "UserID")]
        public int UserID { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Signed Date")]
        [DataType(DataType.DateTime)]
        public System.DateTime DateSigned
        {
            get
            {
                return System.DateTime.Now;
            }
            set { DateSigned = value; }
        }
        public virtual UserProfileInfo UserProfileInfo { get; set; }
        public virtual Campaign Campaign { get; set; }
    }
}