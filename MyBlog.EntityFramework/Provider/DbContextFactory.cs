using System.Runtime.Remoting.Messaging;

namespace MyBlog.EntityFramework.Provider
{
    public class DbContextFactory
    {
        public static MyblogDbContext GetCurrentContext() 
        {
            MyblogDbContext _context = CallContext.GetData("myblogconnection") as MyblogDbContext;
            if (_context == null) 
            {
                _context = new MyblogDbContext();
                CallContext.SetData("myblogconnection", _context);
            }

            return _context;
        }
    }
}
