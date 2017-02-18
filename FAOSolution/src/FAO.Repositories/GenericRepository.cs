using FAO.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FAO.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DbContext dbContext;
        protected DbSet<T> dbSet;

        public GenericRepository(FAODbContext context)
        {
            this.dbContext = context;

            // Create dbset to work with.
            if (this.dbContext != null)
            {
                this.dbSet = dbContext.Set<T>();
            }
        }

        #region IGenericRepository<T> implementation

        public virtual IQueryable<T> AsQueryable()
        {
            return this.dbSet.AsQueryable();
        }

        public IEnumerable<T> GetAll()
        {
            return this.dbSet;
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).AsEnumerable();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return this.dbSet.Where(predicate);
        }

        public T GetSingle(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).FirstOrDefault();
        }

        public T GetFirst(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).FirstOrDefault();
        }

        public void Add(T entity)
        {
            if (dbSet != null)
            {
                dbSet.Add(entity);
            }
        }

        public void Delete(T entity)
        {
            if (dbSet != null)
            {
                dbSet.Attach(entity);
                dbSet.Remove(entity);
            }
        }

        public void Update(T entity)
        {
            if (dbSet != null && dbContext != null)
            {
                dbSet.Attach(entity);
                dbContext.Entry(entity).State = EntityState.Modified;
            }
            return;
        }

        public int SaveChanges(T entity)
        {
            return dbContext.SaveChanges();
        }

        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return dbContext.Database.ExecuteSqlCommand(sql, parameters);
        }

        #endregion
    }
}
