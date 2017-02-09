using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Entity
{
    [Table("user")]
    public class UserRepo
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public bool Sex { get; set; }

        public string HeadImgUrl { get; set; }

        public string Email { get; set; }

        public DateTime CreateAt { get; set; }
    }
}
