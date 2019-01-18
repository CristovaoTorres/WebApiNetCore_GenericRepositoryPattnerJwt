using System;
using System.Collections.Generic;
using System.Text;
using WebApiNetCore_GenericRepositoryPattnerJwt.Core.Models;

namespace WebApiNetCore_GenericRepositoryPattnerJwt.Core.Interface
{
    public interface IUnitOfWork
    {

        IGenericRepository<Aluno> AlunoRepository { get; }

    }
}
