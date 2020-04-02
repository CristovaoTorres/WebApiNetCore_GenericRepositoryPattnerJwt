using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VcmSuite3x_api.Core.Interface;
using VcmSuite3x_api.Core.Models;

namespace VcmSuite3x_api.Core.Models
{

    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {


        #region Constructor and Properties
        private readonly VCMContext _context;
        internal DbSet<TEntity> dbSet;
        public GenericRepository(VCMContext context)
        {
            _context = new VCMContext();
            this.dbSet = _context.Set<TEntity>();
        }

        #endregion

        #region Gets
        public virtual IQueryable<TEntity> GetAll()
        {

            return dbSet.AsQueryable();
        }
        public IQueryable<TEntity> GetWithFilter(Expression<Func<TEntity, bool>> filter)
        {
            IQueryable<TEntity> query = dbSet;

            return query = query.Where(filter);
        }
        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            try
            {
                IQueryable<TEntity> query = dbSet;

                if (filter != null)
                    query = query.Where(filter);

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
        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                               string includeProperties = "")
        {

            try
            {
                IQueryable<TEntity> query = dbSet;

                if (filter != null)
                    query = query.Where(filter);

                if (!string.IsNullOrEmpty(includeProperties))
                {
                    foreach (var includeProperty in includeProperties.Split
                        (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProperty);
                    }
                }

                if (orderBy != null)
                    return orderBy(query);

                else
                    return query;
            }
            catch (Exception ex)
            {

                throw;
            }


        }
        public virtual TEntity GetWithIncludeAll(Expression<Func<TEntity, bool>> filter = null)
        {
            try
            {
                IQueryable<TEntity> query = dbSet;

                if (filter != null)
                    query = query.Where(filter);


                foreach (var property in _context.Model.FindEntityType(typeof(TEntity)).GetNavigations())
                    query = query.Include(property.Name);


                return query.FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public virtual TEntity GetQuery(
            Expression<Func<TEntity, bool>> filter = null,
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

        public virtual int Count(Expression<Func<TEntity, bool>> filter = null)
        {
            try
            {
                var retorno = _context.Set<TEntity>().Count(filter);
                return retorno;
            }
            catch (Exception ex)
            {
                throw;
            }
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
                if (entity != null)
                {
                    dbSet.RemoveRange(entity);
                    _context.SaveChanges();
                }

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
                if (entityToDelete != null)
                {
                    dbSet.Remove(entityToDelete);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public virtual void Delete(Expression<Func<TEntity, bool>> filter)
        {
            try
            {

                IQueryable<TEntity> query = dbSet;

                query = query.Where(filter);

                if (query.FirstOrDefault() != null)
                {
                    dbSet.Remove(query.FirstOrDefault());
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region update

        public virtual void Update(TEntity entity)
        {
            dbSet.Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public async Task<List<Entidade>> EntidadesEntity(string exp)
        {
            try
            {
                #region Cast Expres
                var optionsBlend = ScriptOptions.Default.AddReferences(typeof(Blend).Assembly);
                Func<Blend, bool> blendexp = await CSharpScript.EvaluateAsync<Func<Blend, bool>>(exp, optionsBlend);

                var optionsEntidade = ScriptOptions.Default.AddReferences(typeof(Conjunto).Assembly);
                Func<Conjunto, bool> conjueExp = await CSharpScript.EvaluateAsync<Func<Conjunto, bool>>(exp, optionsEntidade);

                var optionsContrato = ScriptOptions.Default.AddReferences(typeof(Contrato).Assembly);
                Func<Contrato, bool> contExp = await CSharpScript.EvaluateAsync<Func<Contrato, bool>>(exp, optionsContrato);

                var optionsdes = ScriptOptions.Default.AddReferences(typeof(Desconto).Assembly);
                Func<Desconto, bool> descExp = await CSharpScript.EvaluateAsync<Func<Desconto, bool>>(exp, optionsdes);

                var optionsEst = ScriptOptions.Default.AddReferences(typeof(Estado).Assembly);
                Func<Estado, bool> estExp = await CSharpScript.EvaluateAsync<Func<Estado, bool>>(exp.Replace("Codigo", "Sigla"), optionsEst);

                var optionsfai = ScriptOptions.Default.AddReferences(typeof(FaixaDesconto).Assembly);
                Func<FaixaDesconto, bool> faixExp = await CSharpScript.EvaluateAsync<Func<FaixaDesconto, bool>>(exp, optionsfai);

                var optfaxCusExpree = ScriptOptions.Default.AddReferences(typeof(FaixaCustoFixo).Assembly);
                Func<FaixaCustoFixo, bool> faxCusExpree = await CSharpScript.EvaluateAsync<Func<FaixaCustoFixo, bool>>(exp, optfaxCusExpree);

                var optfaxfam = ScriptOptions.Default.AddReferences(typeof(Familia).Assembly);
                Func<Familia, bool> famExpr = await CSharpScript.EvaluateAsync<Func<Familia, bool>>(exp, optfaxfam);

                var optPais = ScriptOptions.Default.AddReferences(typeof(Pais).Assembly);
                Func<Pais, bool> paisExpree = await CSharpScript.EvaluateAsync<Func<Pais, bool>>(exp, optPais);

                var optPeriodo = ScriptOptions.Default.AddReferences(typeof(Periodo).Assembly);
                Func<Periodo, bool> periExpr = await CSharpScript.EvaluateAsync<Func<Periodo, bool>>(exp, optPeriodo);

                var optPeriodoAgregado = ScriptOptions.Default.AddReferences(typeof(PeriodoAgregado).Assembly);
                Func<PeriodoAgregado, bool> periodAExpree = await CSharpScript.EvaluateAsync<Func<PeriodoAgregado, bool>>(exp, optPeriodoAgregado);

                var optPrecoBase = ScriptOptions.Default.AddReferences(typeof(PrecoBase).Assembly);
                Func<PrecoBase, bool> precExpr = await CSharpScript.EvaluateAsync<Func<PrecoBase, bool>>(exp, optPrecoBase);

                var optProduto = ScriptOptions.Default.AddReferences(typeof(Produto).Assembly);
                Func<Produto, bool> produExpree = await CSharpScript.EvaluateAsync<Func<Produto, bool>>(exp, optProduto);

                var optRegiao = ScriptOptions.Default.AddReferences(typeof(Regiao).Assembly);
                Func<Regiao, bool> regiExpr = await CSharpScript.EvaluateAsync<Func<Regiao, bool>>(exp, optRegiao);

                var optRestricao = ScriptOptions.Default.AddReferences(typeof(Restricao).Assembly);
                Func<Restricao, bool> restExpree = await CSharpScript.EvaluateAsync<Func<Restricao, bool>>(exp, optRestricao);

                var optSilo = ScriptOptions.Default.AddReferences(typeof(Silo).Assembly);
                Func<Silo, bool> siloExpress = await CSharpScript.EvaluateAsync<Func<Silo, bool>>(exp, optSilo);

                var optValvula = ScriptOptions.Default.AddReferences(typeof(Valvula).Assembly);
                Func<Valvula, bool> valExpree = await CSharpScript.EvaluateAsync<Func<Valvula, bool>>(exp, optValvula);

                var optCorrente = ScriptOptions.Default.AddReferences(typeof(Corrente).Assembly);
                Func<Corrente, bool> corrExpress = await CSharpScript.EvaluateAsync<Func<Corrente, bool>>(exp, optCorrente);

                var optNo = ScriptOptions.Default.AddReferences(typeof(No).Assembly);
                Func<No, bool> noExpress = await CSharpScript.EvaluateAsync<Func<No, bool>>(exp, optNo);

                var optEntidade = ScriptOptions.Default.AddReferences(typeof(Entidade).Assembly);
                Func<Entidade, bool> entidadeExpress = await CSharpScript.EvaluateAsync<Func<Entidade, bool>>(exp, optEntidade);
                #endregion



                IQueryable<Entidade> entidades;
                List<Entidade> entidadesList = new List<Entidade>();
                using (var context = new VCMContext())
                {

                    entidades = ((from a in context.Blend.Where(blendexp) select new Entidade { Codigo = a.Codigo, Id = a.Id, TipoEntidadeId = a.TipoEntidadeId, TopologiaId = a.TopologiaId })
                   .Concat((from b in context.Conjunto.Where(conjueExp) select new Entidade { Codigo = b.Codigo, Id = b.Id, TipoEntidadeId = b.TipoEntidadeId, TopologiaId = b.TopologiaId })
                   .Concat((from c in context.Contrato.Where(contExp) select new Entidade { Codigo = c.Codigo, Id = c.Id, TipoEntidadeId = c.TipoEntidadeId, TopologiaId = c.TopologiaId })
                   .Concat((from d in context.Desconto.Where(descExp) select new Entidade { Codigo = d.Codigo, Id = d.Id, TipoEntidadeId = d.TipoEntidadeId, TopologiaId = d.TopologiaId })
                   .Concat((from e in context.Estado.Where(estExp) select new Entidade { Codigo = e.Sigla, Id = e.Id, TipoEntidadeId = e.TipoEntidadeId, TopologiaId = e.TopologiaId })
                   .Concat((from f in context.FaixaDesconto.Where(faixExp) select new Entidade { Codigo = f.Codigo, Id = f.Id, TipoEntidadeId = f.TipoEntidadeId, TopologiaId = f.TopologiaId })
                   .Concat((from g in context.FaixaCustoFixo.Where(faxCusExpree) select new Entidade { Codigo = g.Codigo, Id = g.Id, TipoEntidadeId = g.TipoEntidadeId, TopologiaId = g.TopologiaId })
                   .Concat((from h in context.Familia.Where(famExpr) select new Entidade { Codigo = h.Codigo, Id = h.Id, TipoEntidadeId = h.TipoEntidadeId, TopologiaId = h.TopologiaId })
                   .Concat((from i in context.Pais.Where(paisExpree) select new Entidade { Codigo = i.Codigo, Id = i.Id, TipoEntidadeId = i.TipoEntidadeId, TopologiaId = i.TopologiaId })
                   .Concat((from k in context.Periodo.Where(periExpr) select new Entidade { Codigo = k.Codigo, Id = k.Id, TipoEntidadeId = k.TipoEntidadeId, TopologiaId = k.TopologiaId })
                   .Concat((from l in context.PeriodoAgregado.Where(periodAExpree) select new Entidade { Codigo = l.Codigo, Id = l.Id, TipoEntidadeId = l.TipoEntidadeId, TopologiaId = l.TopologiaId })
                   .Concat((from m in context.PrecoBase.Where(precExpr) select new Entidade { Codigo = m.Codigo, Id = m.Id, TipoEntidadeId = m.TipoEntidadeId, TopologiaId = m.TopologiaId })
                   .Concat((from n in context.Produto.Where(produExpree) select new Entidade { Codigo = n.Codigo, Id = n.Id, TipoEntidadeId = n.TipoEntidadeId, TopologiaId = n.TopologiaId })
                   .Concat((from o in context.Regiao.Where(regiExpr) select new Entidade { Codigo = o.Codigo, Id = o.Id, TipoEntidadeId = o.TipoEntidadeId, TopologiaId = o.TopologiaId })
                   .Concat((from p in context.Restricao.Where(restExpree) select new Entidade { Codigo = p.Codigo, Id = p.Id, TipoEntidadeId = p.TipoEntidadeId, TopologiaId = p.TopologiaId })
                   .Concat((from q in context.Silo.Where(siloExpress) select new Entidade { Codigo = q.Codigo, Id = q.Id, TipoEntidadeId = q.TipoEntidadeId, TopologiaId = q.TopologiaId })
                   .Concat((from r in context.Valvula.Where(valExpree) select new Entidade { Codigo = r.Codigo, Id = r.Id, TipoEntidadeId = r.TipoEntidadeId, TopologiaId = r.TopologiaId })
                   .Concat((from p in this._context.Propriedade
                            join pt in this._context.PropriedadeTopologia on p.Id equals pt.PropriedadeId
                            join te in this._context.TipoEntidade on new { a = "Propriedade" } equals new { a = te.Nome }
                            where p.TipoPropriedadeId != null
                            select new Entidade { Id = pt.Id, TipoEntidadeId = te.Id, TopologiaId = pt.TopologiaId })

                            .Concat((from co in context.Corrente.Where(corrExpress) select new Entidade { Codigo = co.Codigo, Id = co.Id, TipoEntidadeId = co.TipoEntidadeId, TopologiaId = co.TopologiaId })
                            .Concat((from no in context.No.Where(noExpress) select new Entidade { Codigo = no.Codigo, Id = no.Id, TipoEntidadeId = no.TipoEntidadeId, TopologiaId = no.TopologiaId })

                   )))))))))))))))))))).AsQueryable();

                    entidadesList = entidades.Where(entidadeExpress).ToList();

                }
                return entidadesList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void AddOrUpdate(TEntity entity)
        {
            var entry = _context.Entry(entity);
            IKey primaryKey = entry.Metadata.FindPrimaryKey();
            if (primaryKey != null)
            {
                object[] keys = primaryKey.Properties.Select(x => x.FieldInfo.GetValue(entity)).ToArray();
                TEntity result = _context.Find<TEntity>(keys);
                if (result == null)
                {
                    _context.Add(entity);
                }
                else
                {
                    _context.Entry(result).State = EntityState.Detached;
                    _context.Update(entity);
                }
            }
            _context.SaveChanges();

        }


        #region Lixo
        //public List<Entidade> EntidadesEntity(Func<Blend, bool> blendexp, Func<Conjunto, bool> conjuExp,
        //                            Func<Contrato, bool> contExp, Func<Desconto, bool> descExp,
        //                            Func<Estado, bool> estExp, Func<FaixaDesconto, bool> faixExp,
        //                            Func<FaixaCustoFixo, bool> faxCusExpree, Func<Familia, bool> famExpr,
        //                            Func<Pais, bool> paisExpree, Func<Periodo, bool> periExpr,
        //                            Func<PeriodoAgregado, bool> periodAExpree, Func<PrecoBase, bool> precExpr,
        //                            Func<Produto, bool> produExpree, Func<Regiao, bool> regiExpr,
        //                            Func<Restricao, bool> restExpree, Func<Silo, bool> siloExpress,
        //                            Func<Valvula, bool> valExpree, Func<PropriedadeTopologia, bool> propExpree,
        //                            Func<TipoEntidade, bool> tipoEExpree, Func<Corrente, bool> corrExpress,
        //                            Func<No, bool> noExpress, Func<Entidade, bool> entidadeExpress)
        //{
        //    //[vw_Entidade]
        //    //[vw_EntidadeTopologia]




        //    try
        //    {
        //        IQueryable<Entidade> entidades;
        //        List<Entidade> entidadesList = new List<Entidade>();
        //        using (var context = new VCMContext())
        //        {

        //            entidades = ((from a in context.Blend.Where(blendexp) select new Entidade { Id = a.Id, TipoEntidadeId = a.TipoEntidadeId, TopologiaId = a.TopologiaId })
        //           .Concat((from b in context.Conjunto.Where(conjuExp) select new Entidade { Id = b.Id, TipoEntidadeId = b.TipoEntidadeId, TopologiaId = b.TopologiaId })
        //           .Concat((from c in context.Contrato.Where(contExp) select new Entidade { Id = c.Id, TipoEntidadeId = c.TipoEntidadeId, TopologiaId = c.TopologiaId })
        //           .Concat((from d in context.Desconto.Where(descExp) select new Entidade { Id = d.Id, TipoEntidadeId = d.TipoEntidadeId, TopologiaId = d.TopologiaId })
        //           .Concat((from e in context.Estado.Where(estExp) select new Entidade { Id = e.Id, TipoEntidadeId = e.TipoEntidadeId, TopologiaId = e.TopologiaId })
        //           .Concat((from f in context.FaixaDesconto.Where(faixExp) select new Entidade { Id = f.Id, TipoEntidadeId = f.TipoEntidadeId, TopologiaId = f.TopologiaId })
        //           .Concat((from g in context.FaixaCustoFixo.Where(faxCusExpree) select new Entidade { Id = g.Id, TipoEntidadeId = g.TipoEntidadeId, TopologiaId = g.TopologiaId })
        //           .Concat((from h in context.Familia.Where(famExpr) select new Entidade { Id = h.Id, TipoEntidadeId = h.TipoEntidadeId, TopologiaId = h.TopologiaId })
        //           .Concat((from i in context.Pais.Where(paisExpree) select new Entidade { Id = i.Id, TipoEntidadeId = i.TipoEntidadeId, TopologiaId = i.TopologiaId })
        //           .Concat((from k in context.Periodo.Where(periExpr) select new Entidade { Id = k.Id, TipoEntidadeId = k.TipoEntidadeId, TopologiaId = k.TopologiaId })
        //           .Concat((from l in context.PeriodoAgregado.Where(periodAExpree) select new Entidade { Id = l.Id, TipoEntidadeId = l.TipoEntidadeId, TopologiaId = l.TopologiaId })
        //           .Concat((from m in context.PrecoBase.Where(precExpr) select new Entidade { Id = m.Id, TipoEntidadeId = m.TipoEntidadeId, TopologiaId = m.TopologiaId })
        //           .Concat((from n in context.Produto.Where(produExpree) select new Entidade { Id = n.Id, TipoEntidadeId = n.TipoEntidadeId, TopologiaId = n.TopologiaId })
        //           .Concat((from o in context.Regiao.Where(regiExpr) select new Entidade { Id = o.Id, TipoEntidadeId = o.TipoEntidadeId, TopologiaId = o.TopologiaId })
        //           .Concat((from p in context.Restricao.Where(restExpree) select new Entidade { Id = p.Id, TipoEntidadeId = p.TipoEntidadeId, TopologiaId = p.TopologiaId })
        //           .Concat((from q in context.Silo.Where(siloExpress) select new Entidade { Id = q.Id, TipoEntidadeId = q.TipoEntidadeId, TopologiaId = q.TopologiaId })
        //           .Concat((from r in context.Valvula.Where(valExpree) select new Entidade { Id = r.Id, TipoEntidadeId = r.TipoEntidadeId, TopologiaId = r.TopologiaId })
        //           .Concat((from p in this._context.Propriedade
        //                    join pt in this._context.PropriedadeTopologia on p.Id equals pt.PropriedadeId
        //                    join te in this._context.TipoEntidade on new { a = "Propriedade" } equals new { a = te.Nome }
        //                    where p.TipoPropriedadeId != null
        //                    select new Entidade { Id = pt.Id, TipoEntidadeId = te.Id, TopologiaId = pt.TopologiaId })

        //                    .Concat((from co in context.Corrente.Where(corrExpress) select new Entidade { Id = co.Id, TipoEntidadeId = co.TipoEntidadeId, TopologiaId = co.TopologiaId })
        //                    .Concat((from no in context.No.Where(noExpress) select new Entidade { Id = no.Id, TipoEntidadeId = no.TipoEntidadeId, TopologiaId = no.TopologiaId })

        //           )))))))))))))))))))).AsQueryable();

        //            entidadesList = entidades.Where(entidadeExpress).ToList();

        //        }
        //        return entidadesList;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}
        #endregion
        #endregion
    }
}


