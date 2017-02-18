using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using FAO.DAL;
using FAO.Repositories.Interfaces;
using System.Linq.Expressions;

namespace FAO.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext dbContext;
        protected DbSet<TEntity> dbSet;

        public Repository(FAODbContext context)
        {
            this.dbContext = context;

            // Create dbset to work with.
            if (dbContext != null)
            {
                dbSet = dbContext.Set<TEntity>();
            }
        }

        public virtual TEntity GetSingle(Expression<Func<TEntity, bool>> where)
        {
            return dbSet.Where(where).FirstOrDefault();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return this.dbSet;
        }

        public virtual TEntity Add(TEntity entity)
        {
            TEntity added = null;
            if (dbSet != null)
            {
                this.dbSet.Add(entity);
                this.dbContext.SaveChanges();
            }
            return added;
        }

        public virtual TEntity Update(TEntity entity)
        {
            TEntity updated = null;
            if (dbSet != null && dbContext != null)
            {
                this.dbContext.SaveChanges();
            }
            return updated;
        }

        public virtual void Delete(TEntity entity)
        {
            if (dbSet != null)
            {
                dbSet.Remove(entity);
                this.dbContext.SaveChanges();
            }
        }
    }
}
