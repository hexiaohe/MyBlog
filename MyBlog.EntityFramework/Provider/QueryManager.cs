using System.Collections.Generic;
using System.Linq;
using MyBlog.EntityFramework.IProvider;
using MySql.Data.MySqlClient;

namespace MyBlog.EntityFramework.Provider
{
    public class QueryManager : IQueryManager
    {
        public IEnumerable<T> GetList<T>(string sql)
        {
            using (var context = new MyblogDbContext())
            {
                return context.Database.SqlQuery<T>(sql).ToList();
            }
        }

        public IEnumerable<T> GetList<T>(string sql, IDictionary<string, object> parameters)
        {
            using (var context = new MyblogDbContext())
            {
                return context.Database.SqlQuery<T>(sql, parameters.Select(x => new MySqlParameter {ParameterName = x.Key, Value = x.Value}).ToArray()).ToList();
            }
        }

        public string GetName()
        {
            return "Nick";
        }

        public List<Org> GetList()
        {
            return new List<Org> { new Org { OrgId = 1, OrgUserId = 1 }, new Org { OrgId = 2, OrgUserId = 2 } };
        }
    }

    public class Org
    {
        public long OrgId { get; set; }

        public long OrgUserId { get; set; }
    }
}
