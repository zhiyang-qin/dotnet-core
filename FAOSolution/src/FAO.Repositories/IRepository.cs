using System;
using System.Linq;
using System.Linq.Expressions;

namespace FAO.Repositories.Interfaces
{
    public interface IRepository<TEntity>
    {
        TEntity GetSingle(Expression<Func<TEntity, bool>> where);

        IQueryable<TEntity> GetAll();

        TEntity Add(TEntity entity);

        TEntity Update(TEntity entity);

        void Delete(TEntity entity);
    }
}