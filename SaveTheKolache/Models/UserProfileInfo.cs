using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SaveTheKolache.Models
{
    public class UserProfileInfo
    {
        [Key]
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

    }
}