using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FAO.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> AsQueryable();

        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        T GetSingle(Expression<Func<T, bool>> where);
        T GetFirst(Expression<Func<T, bool>> where);

        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);

        int SaveChanges(T entity);

        int ExecuteSqlCommand(string sql, params object[] parameters);
    }
}
