using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vlog.Models;

namespace Vlog.Controllers
{
    public class ArticleController : Controller
    {
        private DatabaseContext database;
        public ArticleController()
        {
            database = new DatabaseContext();
        }
        // GET: Article
        /// <summary>
        /// 文章列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //TODO:article order br time
            List<Article> articles = database.Articles.ToList();
            ViewBag.Articles = articles;
            return View();
        }

        /// <summary>
        /// 登录之后用户主页面
        /// </summary>
        /// <returns></returns>
        public ActionResult User()
        {
            User user = (User)Session["user"];
            if (user == null)
            {
                return RedirectToAction("Login", "User");
            }
            List<Article> articles = (from item in database.Articles where user.UserId == item.UserId select item).ToList();
            ViewBag.Articles = articles;
            return View();
        }

        /// <summary>
        /// 文章详情
        /// </summary>
        /// <returns></returns>
        public ActionResult Detail(int articleId)
        {
            Article article = database.Articles.Find(articleId);
            ViewBag.Article = article;

            while (-1 != article.Content.IndexOf("\n"))
            {
                article.Content = article.Content.Replace("\n", "<br/>");
            }
            //item.Content = item.Content.Replace("\n", "<br/>");
            //item.Content= item.Content.Replace("char(13)", "<br/>");
            return View();
        }

        public ActionResult Update(int articleId)
       {
            Article article = database.Articles.Find(articleId);
            ViewBag.Article = article;
            return View();
        }
        public ActionResult UpdateSubmit(int articleId, string title, string content)
        {
            Article article = database.Articles.Find(articleId);
            article.Title = title;
            article.Content = content;
            database.SaveChanges();
            return View();
        }
        public ActionResult Insert()
        {
            return View();
        }
        public ActionResult InsertSubmit(string title, string content)
        {
            //TODO:when the article is null
            while (-1 != content.IndexOf("<br>"))
            {
                content = content.Replace("<br>", "\n");
            }
            Article article = new Article
            {
                Title = title,
                Content = content,
                Time = DateTime.Now,
                UserId = ((User)Session["user"]).UserId,
            };
            database.Articles.Add(article);
            database.SaveChanges();
            return View();
        }
    }
}