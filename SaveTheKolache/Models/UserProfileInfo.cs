using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Profile;

namespace SaveTheKolache.Models
{
    public class UserProfileInfo : ProfileBase
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int UserID { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name="Create Date")]
        public System.DateTime CreateDate { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name="Birth Date")]
        public System.DateTime BirthDate { get; set; }
        [Display(Name="First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }
        [Display(Name = "Phone Number")]
        public string CellPhone { get; set; }

        //public bool Activity
        //{
        //    get { return true; }
        //    set { Activity = value; }
        //}


    }
}