using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.WebPages;
using Vlog.Models;

namespace Vlog.Controllers
{
    public class UserController : Controller
    {
        private DatabaseContext database;
        public UserController()
        {
            database = new DatabaseContext();
        }
        public ActionResult Login(string errorMessage)
        {
            Session.RemoveAll();
            if (!errorMessage.IsEmpty())
            {
                ViewBag.ErrorMessage = errorMessage;
            }
            return View();
        }
        public ActionResult LoginSubmit(string name,string password)
        {
            //TODO:para check
            List<User> result =(from u in database.Users where u.Name == name select u).ToList();
            if(result.Count==0)
            {
                RouteValueDictionary values = new RouteValueDictionary();
                values.Add("errorMessage", "wrong name!");
                return RedirectToAction("Login",values);
            }
            if (result.First().Password != password)
            {
                RouteValueDictionary values = new RouteValueDictionary();
                values.Add("errorMessage", "wrong password!");
                return RedirectToAction("Login", values);
            }
            Session.Add("user", result.First());
            return View();
        }
        public ActionResult SignUp()
        {
            Session.RemoveAll();
            return View();
        }
        public ActionResult SignUpSubmit(string name, string password, string sex)
        {
            User user = new User
            {
                Name = name,
                Password = password,
                Sex = sex == "Male" ? "M" : "F",
                Time = DateTime.Now
            };
            database.Users.Add(user);
            database.SaveChanges();
            return View();
        }
    }
}