using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vlog.Models
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Time { get; set; }
        public int Hit { get; set; }       //点赞数
        public virtual int UserId { get; set; }
        public virtual User User { get; set; }
    }
}