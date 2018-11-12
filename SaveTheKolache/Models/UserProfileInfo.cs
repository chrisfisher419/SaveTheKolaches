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
        public System.DateTime CreateDate { get; set; }
        [DataType(DataType.DateTime)]
        public System.DateTime BirthDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string EmailAddress { get; set; }
        public string CellPhone { get; set; }

        //public bool Activity
        //{
        //    get { return true; }
        //    set { Activity = value; }
        //}


    }
}