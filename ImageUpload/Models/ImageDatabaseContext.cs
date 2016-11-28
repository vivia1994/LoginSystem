using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ImageUpload.Models
{
    public class ImageDatabaseContext : DbContext
    {
        public DbSet <Image> Images { get; set; }
    }
}