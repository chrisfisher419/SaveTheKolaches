using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaveTheKolache.DAL
{
    public class EFDbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<EFDbContext>
    {

    }
}