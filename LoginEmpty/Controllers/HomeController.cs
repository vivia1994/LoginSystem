using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.WebPages;
using LoginEmpty.Models;

namespace LoginEmpty.Controllers
{
    [Authorize]         //这个控制器中的所有操作都允许注册用户访问，禁止匿名访问
    public class HomeController : Controller
    {
        // GET: Home
        [AllowAnonymous]        //允许匿名访问
        public ActionResult Index()
        {
            Session.RemoveAll();
            return View();
        }

        // GET: Home/Login
        // [Authorize]         //点击“Login”按钮时会要求登录
        //启动Windows验证
        public ActionResult Login(string name, string password)
        {
            Session.RemoveAll();
            DatabaseContext userDbContext = new DatabaseContext();
            DbSqlQuery<User> result = userDbContext.Users.SqlQuery("Select * from Users where Name = @p0", name);
            if (!result.Any())
                return RedirectToAction("Index");
            if (result.First().Password != password)        //密码错误
                return Redirect("Index");
            Session.Add("userInfo", result.First());
            return Redirect("Info");
        }
        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        public ActionResult LogOff()
        {
            Session.RemoveAll();
            return RedirectToAction("Index");
        }

        // GET: Home
        // 目的是拿出所有的用户信息：
        //[Authorize]
        /// <summary>
        /// article info
        /// </summary>
        /// <returns></returns>
        public ActionResult Info()
        {
            User user = (User)Session["userInfo"];
            ViewBag.UserInfo = user;

            if (ViewBag.UserInfo == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.userName = user.Name;
                DatabaseContext articleDbContext = new DatabaseContext();
                List<ArticleInfo> userArticle = articleDbContext.ArticleInfoes.ToList();
                ViewBag.UserArticles = userArticle;
                ViewBag.count=userArticle.Count;
                return View();
            }

        }
        [AllowAnonymous]
        public ActionResult Register(string name, string password, string sex,DateTime? time)
        {
            //    DatabaseContext userDbContext = new DatabaseContext();
            //    var r = from s in userDbContext.Users select s.Name.Equals(name);
            //var count = 0;
            //ViewBag.errorMessage = "";
            //count =r.Count();
            if (ModelState.IsValid)

          {
              if (!name.IsEmpty() && !password.IsEmpty()) /*&& count <= 0*/
              {
                  DatabaseContext newUser = new DatabaseContext();
                  newUser.Users.Add(new User()
                  {
                      Name = name,
                      Password = password,
                      Sex = sex,
                      Time = DateTime.Now
                  });

                  //  ViewBag.successMessage = "Regist successfully!";
                  newUser.SaveChanges();
              }
              //try
              //{
              //    newUser.SaveChanges();
              //}
              //catch (DbEntityValidationException ex)
              //{
              //    StringBuilder errors = new StringBuilder();
              //    IEnumerable<DbEntityValidationResult> validationResult = ex.EntityValidationErrors;
              //    foreach (DbEntityValidationResult result in validationResult)
              //    {
              //        ICollection<DbValidationError> validationError = result.ValidationErrors;
              //        foreach (DbValidationError err in validationError)
              //        {
              //            errors.Append(err.PropertyName + ":" + err.ErrorMessage + "\r\n");
              //        }
              //    Console.WriteLine(errors.ToString());
              //简写
              //var validerr = ex.EntityValidationErrors.First().ValidationErrors.First();
              //Console.WriteLine(validerr.PropertyName + ":" + validerr.ErrorMessage);
              else
              {
                  //{
                  //    if (count>0&&!name.IsEmpty())
                  //    {
                  ViewBag.errorMessage = "input wrong!";
                  //}
                  //else if(name.IsEmpty()||password.IsEmpty())
                  //{
                  //    ViewBag.errorMessage = "Name or password cannot be null!";
                  //}
                  return View();
              }
          }
            return RedirectToAction("Index");
        }

        public ActionResult Search(string q)
        {
            DatabaseContext userResultDatabaseContext = new DatabaseContext();
            var user = userResultDatabaseContext.Users.Where(x => x.Name.Contains(q)).ToList();
            ViewBag.user = user;
            return PartialView(user);
        }

       
    }
}