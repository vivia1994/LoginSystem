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
                    //获取加密服务  
                    MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                    byte[] buffer = new byte[file.InputStream.Length];
                    file.InputStream.Read(buffer, 0, buffer.Length);
                    byte[] md5Key = md5.ComputeHash(buffer);
                    string path = Path.Combine(Server.MapPath("/Content/images"), ToMD5String(md5Key) + ".jpg");
                    file.SaveAs(path);
                    //数据库操作
                    Image image = new Image();
                    image.ImageUrl = "/Content/images/" + ToMD5String(md5Key) + ".jpg";
                    image.UploadTitle = uploadTitle;
                    db.Images.Add(image);
                    db.SaveChanges();

                    Thumbnail thumbnail = new Thumbnail();
                    thumbnail.ThumbnailUrl = "/Content/Tumbnail/" + ToMD5String(md5Key) + ".jpg";
                    thumbnail.ThumbnailTitle = uploadTitle;
                    db.Thumbnails.Add(thumbnail);
                    db.SaveChanges();

                    string thumbNailPath = Path.Combine(Server.MapPath("/Content/Tumbnail/") + ToMD5String(md5Key) + ".jpg");
                    SaveThumbnailImage(path, thumbNailPath, 60, 60);
                    return View();
                }
            }
            return RedirectToAction("Index");
        }
        //public ActionResult Get(string Id)
        //{
        //   Image image =  db.Images.Find(Id);
        //    ViewBag.Image = image;
        //    return View();
        //}

      
        /// <summary>
        /// 图片帮助类
        /// </summary>

            /// <summary>
            /// 缩略图配置类
            /// </summary>
            public class ThumbnailImageOptions
            {
                /// <summary>
                /// 目标文件的路径
                /// </summary>
                public string TargetFileName { get; set; }
                /// <summary>
                /// 宽度
                /// </summary>
                public int Width { get; set; }

                /// <summary>
                /// 高度
                /// </summary>
                public int Height { get; set; }
            }

            /// <summary>
            /// 生成缩略图
            /// </summary>
            /// <param name="srcFileName">原始文件</param>
            /// <param name="targetFileName">目标文件，不能和原始文件的路径相同</param>
            /// <param name="width">图宽度</param>
            /// <param name="heigth">图高度</param>
            public static bool SaveThumbnailImage(string srcFileName, string targetFileName, int width, int heigth)
            {
                if (srcFileName == null)
                {
                    throw new ArgumentNullException("srcFileName");
                }
                if (targetFileName == null)
                {
                    throw new ArgumentNullException("targetFileName");
                }
                return SaveThumbnailImage(srcFileName, new ThumbnailImageOptions[]
                {
                new ThumbnailImageOptions(){ TargetFileName = targetFileName, Width = width, Height = heigth }
                });
            }

            /// <summary>
            /// 生成缩略图
            /// </summary>
            /// <param name="srcFileName">图片源文件的路径</param>
            /// <param name="optionItems">一个或多个配置</param>
            /// <returns></returns>
            public static bool SaveThumbnailImage(string srcFileName, IEnumerable<ThumbnailImageOptions> optionItems)
            {
                if (srcFileName == null)
                {
                    throw new ArgumentNullException("srcFileName");
                }
                if (optionItems == null)
                {
                    throw new ArgumentNullException("items");
                }
                if (!optionItems.Any())
                {
                    return true;
                }
                using (FileStream fs = new FileStream(srcFileName, FileMode.Open))
                {
                    System.Drawing.Image img = System.Drawing.Image.FromStream(fs);
                    try
                    {
                        foreach (ThumbnailImageOptions item in optionItems)
                        {
                            System.Drawing.Image newThumImg = img.GetThumbnailImage(item.Width, item.Height, null, IntPtr.Zero);
                            newThumImg.Save(item.TargetFileName);
                            newThumImg.Dispose();
                        }
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                    finally
                    {
                        img.Dispose();
                    }
                }
            }

        
        [HttpPost]
        public ActionResult TestUpload(HttpPostedFileBase upImg)
        {
            string filePhysicalPath = Server.MapPath("~/Content/" + Path.GetFileName(upImg.FileName));
            upImg.SaveAs(filePhysicalPath);
            string result = "ContentLength：" + upImg.ContentLength + "<br/>ContentType：" + upImg.ContentType + "<br/>FileName：" + upImg.FileName;
            string newFilePhysicalPath = Server.MapPath("~/Content/" + DateTime.Now.ToString("yyyyMMddHHmmssmmm"));
            SaveThumbnailImage(filePhysicalPath, newFilePhysicalPath, 80, 60);
            ViewData["uploadResult"] = result;
            return View();
        }

    }
}