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
            List<Article> articles = database.Articles.ToList();
            ViewBag.Articles = articles;
            //foreach (Article item in articles)
            //{
            //    item.Content = item.Content.Replace(char(10), "<br/>");
            //    item.Content = item.Content.Replace("char(13)", "<br/>");
            //}
            return View();
        }

    }
}