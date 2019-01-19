using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace WebApiNetCore_GenericRepositoryPattnerJwt.Core.Interface
{
    public interface IGenericRepository<TEntity>
    {
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);

        IQueryable<TEntity> Get(
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           string includeProperties = "");

        int Count(Expression<Func<TEntity, bool>> filter = null);

        TEntity GetQuery(
            Expression<Func<TEntity, bool>> filter = null,
            //Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        void Insert(TEntity entity);

        void DeleteRange(List<TEntity> entity);


        void Delete(object id);

        void Delete(TEntity entityToDelete);

        void Update(TEntity entityToUpdate);

        TEntity GetByID(object id);

        void InsertRange(List<TEntity> entity);
    }
}
