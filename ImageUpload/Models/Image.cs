using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageUpload.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string UploadTitle { get; set; }
    }
}