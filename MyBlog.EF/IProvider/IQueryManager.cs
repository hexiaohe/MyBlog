using System.Collections.Generic;

namespace MyBlog.EF.IProvider
{
    public interface IQueryManager
    {
        IEnumerable<T> GetList<T>(string sql);

        IEnumerable<T> GetList<T>(string sql, IDictionary<string, object> parameter);
    }
}
