using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.WebPages;
using Vlog.Models;
using System.Text.RegularExpressions;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

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

        public ActionResult LoginSubmit(string name, string password)
        {
            Thread.Sleep(1000);
            //TODO:para check
            Dictionary<string, object> result = new Dictionary<string, object>();
            List<User> userList = (from u in database.Users where u.Name == name select u).ToList();
            if (userList.Count == 0|| userList.First().Password != password)
            {
                result.Add("flag", false);
                result.Add("reason", "wrong user or password");
                return Json(result);
            }
            Session.Add("user", userList.First());
            result.Add("flag", true);
            return Json(result);
        }

        public ActionResult SignUp()
        {
            Session.RemoveAll();
            return View();
        }

        public ActionResult SignUpSubmit(string name, string password, string sex)
        {
            Thread.Sleep(1000);
            Dictionary<string, object> result = new Dictionary<string, object>();
            List<User> users = (from item in database.Users select item).ToList();
            //Regex r = new Regex("^/w+$");
            //if (!r.IsMatch(name))
            //{
            //    result.Add("flag", false);
            //    result.Add("reason", "wrong user format");
            //    return Json(result);
            //}
            if (name.IsEmpty()) //名字为空
            {
                result.Add("flag", false);
                result.Add("reason", "Please input name!");
                return Json(result);
            }
            if (password.IsEmpty()) //密码为空
            {
                result.Add("flag", false);
                result.Add("reason", "Please input password!");
                return Json(result);
            }
            foreach (User u in users)
            {
                if (u.Name == name) //名字重复
                {
                    result.Add("flag", false);
                    result.Add("reason", "The name has existed!");
                    return Json(result);
                }
            }
            User user = new User
            {
                Name = name,
                Password = password,
                Sex = sex == "Male" ? "M" : "F",
                Time = DateTime.Now
            };
            database.Users.Add(user);
            database.SaveChanges();
            result.Add("flag", true);
            return Json(result);
        }
        public ActionResult GetValidateCode()
        {
            Random random = new Random();
            string textColor = "#" + Convert.ToString(random.Next(99, 256), 16) + Convert.ToString(random.Next(99, 256), 16) + Convert.ToString(random.Next(99, 256), 16);
            Bitmap image = new Bitmap(70, 35);
            Graphics graphic = Graphics.FromImage(image);
            graphic.TextRenderingHint = TextRenderingHint.AntiAlias; //消除锯齿
            string validateCode ="" + random.Next(0, 10) + random.Next(0, 10) + random.Next(0, 10) + random.Next(0, 10);
            ColorConverter colorConvert = new ColorConverter();
            Color fontColor = (Color)colorConvert.ConvertFromString(textColor);
            Font font = new Font("Arial", 18, FontStyle.Bold);
            LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height),
                fontColor, 
                fontColor,
                LinearGradientMode.Horizontal);
            graphic.DrawString(validateCode, font, brush, 2, 2);
            Color backColor = image.GetPixel(1, 1);
            image.MakeTransparent(backColor);
            MemoryStream stream = new MemoryStream();
            image.Save(stream, ImageFormat.Gif);
            return File(stream.ToArray(), "image/gif");
        }
    }
}