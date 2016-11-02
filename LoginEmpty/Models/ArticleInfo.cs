using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Web;

namespace LoginEmpty.Models
{
    public class ArticleInfo
    {
       /* [Key] */                                      //设置非int类型的主键
        public int ArticleInfoId { get; set; }
        public string Article { get; set; }
        public string Content { get; set; }
        public DateTime Time { get; set; }
        public int Hit { get; set; }       //点赞数
        public virtual string Name { get; set; }
        public virtual User User { get; set; }



    }
}