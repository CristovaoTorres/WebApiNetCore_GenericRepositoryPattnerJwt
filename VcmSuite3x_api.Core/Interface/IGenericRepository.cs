using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VcmSuite3x_api.Core.Models;

namespace VcmSuite3x_api.Core.Interface
{
    public interface IGenericRepository<TEntity>
    {
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);

        IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        IQueryable<TEntity> GetWithFilter(
        Expression<Func<TEntity, bool>> filter);

        TEntity GetWithIncludeAll(Expression<Func<TEntity, bool>> filter = null);

        void AddOrUpdate(TEntity entity);

        int Count(Expression<Func<TEntity, bool>> filter = null);

        TEntity GetQuery(
            Expression<Func<TEntity, bool>> filter = null,
            //Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        void Insert(TEntity entity);

        void DeleteRange(List<TEntity> entity);

        void Delete(TEntity entityToDelete);
        void Delete(Expression<Func<TEntity, bool>> filter = null);

        void Update(TEntity entityToUpdate);


        void InsertRange(List<TEntity> entity);
        Task<List<Entidade>> EntidadesEntity(string exp);


    }
}
