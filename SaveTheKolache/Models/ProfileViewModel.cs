using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaveTheKolache.Models
{
    public class ProfileViewModel
    {
        public IList<UserLoginInfo> UserLoginInfo { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string CellPhone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual UserProfileInfo UserProfileInfo { get; set; }
        
    }
}