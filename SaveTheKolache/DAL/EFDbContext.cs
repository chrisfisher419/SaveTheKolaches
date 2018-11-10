using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using SaveTheKolache.Models;

namespace SaveTheKolache.DAL
{
    public class EFDbContext : DbContext
    {
        public EFDbContext() : base("EFDbContext")
        {

        }
        public DbSet<UserProfileInfo> UserProfileInfos { get; set; }
        public DbSet<SignUpList> SignUpLists { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
 
}