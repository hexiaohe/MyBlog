using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Model
{
    [Table("ArticleType")]
    public class ArticleTypeRepo
    {
        public long Id { get; set; }

        public string TypeName { get; set; }

        public string Remark { get; set; }
    }
}
