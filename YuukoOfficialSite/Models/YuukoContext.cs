using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace YuukoOfficialSite.Models
{
    public class YuukoContext : DbContext
    {
        public DbSet<Document> Documents { get; set; }

        public DbSet<Sample> Samples { get; set; }

        public DbSet<Log> Logs { get; set; }

        public YuukoContext() : base("mssqldb")
        {

        }
    }
}