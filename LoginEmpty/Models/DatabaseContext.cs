using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LoginEmpty.Models
{
    public class DatabaseContext : DbContext
    {

        //public DbSet<Login> Logins { get; set; }

        public DbSet<User> Users { get; set; }

        
        public DbSet<ArticleInfo> ArticleInfoes { get; set; }

    }
}