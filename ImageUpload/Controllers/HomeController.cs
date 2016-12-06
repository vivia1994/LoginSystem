using ImageUpload.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageUpload.Controllers
{
    public class HomeController : Controller
    {

        private ImageDatabaseContext database;
        public HomeController()
        {
            database = new ImageDatabaseContext();
        }
        // GET: Home
        public ActionResult Index(string ThumbnailUrl)
        {
            string thumbFileName = ThumbnailUrl.Split(new string[] { "Tumbnail/" }, StringSplitOptions.RemoveEmptyEntries).ToList().ElementAt(1);
            Image imageFileName = database.Images.FirstOrDefault();
            ViewBag.ImageUrl = "/Content/Images" + imageFileName;
            List<Thumbnail> thumbnails = database.Thumbnails.ToList();
            ViewBag.Thumbnails = thumbnails;
            List<Image> images = database.Images.ToList();
            ViewBag.Images = images;
            return View();
        }
    }
}