using System;
using System.Collections.Generic;
using System.Text;
using WebApiNetCore_GenericRepositoryPattnerJwt.Core.Interface;
using WebApiNetCore_GenericRepositoryPattnerJwt.Core.Models;

namespace WebApiNetCore_GenericRepositoryPattnerJwt.Core.Repository
{
    public class UnitOfWork : IUnitOfWork, System.IDisposable
    {

        protected EscolaContext _dbContext;


        private GenericRepository<Aluno> alunoRepository;



        public IGenericRepository<Aluno> AlunoRepository
        {
            get
            {
                if (this.alunoRepository == null)
                {
                    this.alunoRepository = new GenericRepository<Aluno>(_dbContext);
                }
                return alunoRepository;
            }
        }

        #region  Methods


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
