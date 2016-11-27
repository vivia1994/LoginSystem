using ImageUpload.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ImageUpload.Controllers
{
    public class ImageController : Controller
    {
        private ImageDatabaseContext db;
        public ImageController()
        {
            db = new ImageDatabaseContext();
        }
        // GET: ImageController
        public ActionResult Index()
        {
            return View();
        }
        private string ToMD5String(byte[] md5Key)
        {
            StringBuilder result = new StringBuilder();
            foreach(byte item in md5Key)
            {
                result.AppendFormat("{0:X2}", item);
            }
            return result.ToString();
        }
        public ActionResult Upload(HttpPostedFileBase file, string uploadTitle)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    byte[] buffer = new byte[file.InputStream.Length];
                    //获取加密服务  
                    MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                    file.InputStream.Read(buffer, 0, buffer.Length);
                    byte[] md5Key = md5.ComputeHash(buffer);
                    string fileName = ToMD5String(md5Key) + ".jpg";
                    string path = Path.Combine(Server.MapPath("/Content/images"), fileName);
                    file.SaveAs(path);
                    Image image = new Image();
                    image.ImageUrl = "/Content/images/" + fileName;
                    image.UploadTitle = uploadTitle;
                    db.Images.Add(image);
                    db.SaveChanges();
                    return View();
                }
            }
            return RedirectToAction("Index");

        }
    }
}