using MyBlog.Entity;
using System.Data.Entity;

namespace MyBlog.EF.Provider
{
    public class MyblogDbContext: DbContext
    {
        private static readonly string Connection = "myblogconnection";

        public MyblogDbContext() : base(Connection) { }

        public DbSet<UserRepo> User { get; set; }

        public DbSet<ArticleRepo> Article { get; set; }

        public DbSet<ArticleTypeRepo> ArticleType { get; set; }
    }
}
