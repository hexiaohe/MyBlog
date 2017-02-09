using System;
using System.Linq;
using System.Linq.Expressions;
using MyBlog.EF.IProvider;

namespace MyBlog.EF.Provider
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public T Add(T entity) 
        { 
            using(var context = new MyblogDbContext())
            {
                context.Entry<T>(entity).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
                return entity;
            }
        }

        public bool Update(T entity)
        {
            using (var context = new MyblogDbContext())
            {
                context.Set<T>().Attach(entity);
                context.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
                return context.SaveChanges() > 0;
            }
        }

        public bool Delete(T entity)
        {
            using (var context = new MyblogDbContext())
            {
                context.Set<T>().Attach(entity);
                context.Entry<T>(entity).State = System.Data.Entity.EntityState.Deleted;
                return context.SaveChanges() > 0;
            }
        }

        public bool Exist(Expression<Func<T, bool>> anyLamdba)
        {
            using (var context = new MyblogDbContext())
            {
                return context.Set<T>().Any(anyLamdba);
            }
        }

        public int Count(Expression<Func<T, bool>> predicate) 
        {
            using (var context = new MyblogDbContext()) 
            {
                return context.Set<T>().Count(predicate);
            }
        }

        public T Find(Expression<Func<T, bool>> whereLamdba)
        {
            using (var context = new MyblogDbContext())
            {
                T _entity = context.Set<T>().FirstOrDefault<T>(whereLamdba);
                return _entity;
            }
        }

         //Find(u=>{u.id>0})
        public IQueryable<T> FindList(Expression<Func<T, bool>> whereLamdba, string orderName, bool isAsc) 
        {
            using (var context = new MyblogDbContext())
            {
                var _list = context.Set<T>().Where<T>(whereLamdba);
                _list = OrderBy(_list, orderName, isAsc);
                return _list;
            }
        }

        public IQueryable<T> FindPageList(int pageIndex, int pageSize, out int totalRecord, Expression<Func<T, bool>> whereLamdba, string orderName, bool isAsc)
        {
            using (var context = new MyblogDbContext())
            {
                var _list = context.Set<T>().Where<T>(whereLamdba);
                totalRecord = _list.Count();
                _list = OrderBy(_list, orderName, isAsc).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
                return _list;
            }
        }

        private IQueryable<T> OrderBy(IQueryable<T> source, string propertyName, bool isAsc) 
        {
            if (source == null)
                throw new ArgumentNullException("source","不能为空！");

            if (string.IsNullOrWhiteSpace(propertyName))
                return source;

            var _parameter = Expression.Parameter(source.ElementType);
            var _property = Expression.Property(_parameter, propertyName);
            if (_property == null)
                throw new ArgumentNullException("propertyName","属性不存在！");

            var _lambda = Expression.Lambda(_property, _parameter);
            var _methodName = isAsc ? "OrderBy" : "OrderByDescending";
            var _resultExpression = Expression.Call(typeof(Queryable), _methodName, new Type[] { source.ElementType, _property.Type }, source.Expression, Expression.Quote(_lambda));

            return source.Provider.CreateQuery<T>(_resultExpression);
        }
    }
}
