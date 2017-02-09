using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Entity
{
    [Table("Article")]
    public class ArticleRepo
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int TargetType { get; set; }

        public int Issue { get; set; }

        public DateTime IssueAt { get; set; }

        public int ViewCount { get; set; }

        public DateTime CreateAt { get; set; }

        public long CreateBy { get; set; }

        public DateTime UpdateAt { get; set; }

        public long UpdateBy { get; set; }
    }
}
