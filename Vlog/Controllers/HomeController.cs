using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vlog.Models;

namespace Vlog.Controllers
{
    public class HomeController : Controller
    {
        private DatabaseContext database;

        public HomeController()
        {
            database = new DatabaseContext();
        }

        // GET: Home
        public ActionResult Index()
        {
            //TODO:see more articles
            //TODO:html labels 
            List<Article> articles = (from item in database.Articles orderby item.Time descending select item).Take(5).ToList();
            ViewBag.Articles = articles;
            User user = (User)Session["user"];
            ViewBag.User = user;
            return View();
        }

    }
}