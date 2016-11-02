using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace LoginEmpty.Models
{
    //播种数据库
    public class DataBaseDbInitializer: DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            context.Users.Add(
                new User
                {
                    Name = "vivi",
                    //Password = "1",
                    Sex = "女",
                    //Grade = 98.50F
                });
            context.Users.Add(
               new User
               {
                   Name = "Jason",
                   //Password = "1",
                   Sex = "男",
                   //Grade = 99.50F
               });
            //context.ArticleInfoes.Add(
            //    new ArticleInfo
            //    {
            //        ArticleInfoId= 1,
            //        Article = "数据库原理",
            //        Content = "",
            //        Time = 4.0F,
            //        Name = "沈俊"
            //    });
            //context.ArticleInfoes.Add(
            //    new ArticleInfo
            //    {
            //        ArticleInfoId = 2,
            //        Article = "数据结构",
            //        Content = "尹默林",
            //        Time = (2016,10,10),
            //        Name = "计算机学院"
            //    });
            base.Seed(context);
        }
    }
}