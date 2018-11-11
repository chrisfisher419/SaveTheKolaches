using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.Security;

namespace SaveTheKolache.Profile
{
    public class AccountProfile : ProfileBase
    {
        static public AccountProfile CurrentUser
        {
            get
            {
                return (AccountProfile)
                    (ProfileBase.Create(Membership.GetUser().UserName));
            }
        }

        public string FullName
        {
            get { return ((string)(base["FullName"])); }
            set { base["FullName"] = value; Save(); }
        }

        // add additional properties here
    }
}