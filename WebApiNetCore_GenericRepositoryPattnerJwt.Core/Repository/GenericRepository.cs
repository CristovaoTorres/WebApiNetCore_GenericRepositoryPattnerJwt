using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using WebApiNetCore_GenericRepositoryPattnerJwt.Core.Interface;
using WebApiNetCore_GenericRepositoryPattnerJwt.Core.Models;

namespace WebApiNetCore_GenericRepositoryPattnerJwt.Core.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {

        #region Constructor and Properties
        private readonly EscolaContext _context;
        internal DbSet<TEntity> dbSet;
        public GenericRepository(EscolaContext context)
        {
            _context = new EscolaContext();
            this.dbSet = _context.Set<TEntity>();
        }

        #endregion

        #region Gets
        public virtual IQueryable<TEntity> GetAll()
        {

            return dbSet.AsQueryable();
        }



        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            try
            {
                IQueryable<TEntity> query = dbSet;

                if (filter != null)
                {
                    query = query.Where(filter);
                }
                return query;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Collection<TEntity> GetAllCollectionInclude(string includeProperties = "")
        {
            try
            {
                var query = dbSet.AsQueryable();



                if (!string.IsNullOrEmpty(includeProperties))
                {
                    foreach (var includeProperty in includeProperties.Split
                        (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProperty);
                    }
                }

                return new Collection<TEntity>(query.ToList());
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Collection<TEntity> GetProcedure(string Proc, string paramater = null)
        {
            try
            {
                var query = dbSet.FromSql(sql: $"{Proc} {paramater}");

                return new Collection<TEntity>(query.ToList());
            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetWithIncludeAll(Expression<Func<TEntity, bool>> filter = null)
        {

            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }


            foreach (var property in _context.Model.FindEntityType(typeof(TEntity)).GetNavigations())
                query = query.Include(property.Name);


            return query.FirstOrDefault();
        }


        public virtual TEntity GetQuery(
            Expression<Func<TEntity, bool>> filter = null,
            //Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return query.FirstOrDefault();
        }

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual int Count(Expression<Func<TEntity, bool>> filter = null)
        {
            return _context.Set<TEntity>().Count(filter);
        }

        public static void GetInitializedList<T>(T value, int count)
        {
        }

        #endregion

        #region Inserts
        public virtual void Insert(TEntity entity)
        {
            try
            {
                dbSet.Add(entity);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public virtual void InsertRange(List<TEntity> entity)
        {
            try
            {
                dbSet.AddRange(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        #endregion

        #region Deletes
        public virtual void DeleteRange(List<TEntity> entity)
        {
            try
            {
                dbSet.RemoveRange(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public virtual void Delete(object id)
        {

            try
            {
                TEntity entityToDelete = dbSet.Find(id);
                Delete(entityToDelete);
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public virtual void Delete(TEntity entityToDelete)
        {

            try
            {
                dbSet.Remove(entityToDelete);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw;
            }


        }

        #endregion

        #region update
        public virtual void Update(TEntity entityToUpdate)
        {

            try
            {
                dbSet.Update(entityToUpdate);
                _context.Entry(entityToUpdate).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        #endregion
    }
}
