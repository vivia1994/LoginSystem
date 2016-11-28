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
            public ActionResult Index()
        {
            List<Image> images = database.Images.ToList();
            ViewBag.Images = images;
            return View();
        }
    }
}