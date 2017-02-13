using System.Collections.Generic;

namespace MyBlog.EntityFramework.IProvider
{
    public interface IQueryManager
    {
        IEnumerable<T> GetList<T>(string sql);

        IEnumerable<T> GetList<T>(string sql, IDictionary<string, object> parameter);
    }
}
