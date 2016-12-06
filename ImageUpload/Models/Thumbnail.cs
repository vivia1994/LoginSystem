using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageUpload.Models
{
    public class Thumbnail
    {
        public int Id { get; set; }
        public string ThumbnailUrl { get; set; }
        public string ThumbnailTitle { get; set; }
    }
}