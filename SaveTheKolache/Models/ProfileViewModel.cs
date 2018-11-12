using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SaveTheKolache.Models
{
    public class ProfileViewModel
    {
        public IList<UserLoginInfo> UserLoginInfo { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
        [Display(Name = "Phone Number")]
        public string CellPhone { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        //public bool Activity { get; set; }
        [Display(Name = "Birth Date")]
        public System.DateTime BirthDate { get; set; }

        public virtual UserProfileInfo UserProfileInfo { get; set; }
        
    }
}