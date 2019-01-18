using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiNetCore_GenericRepositoryPattnerJwt.Core.Models;
using WebApiNetCore_GenericRepositoryPattnerJwt.Models;

namespace WebApiNetCore_GenericRepositoryPattnerJwt.Domain
{
    public class DomainProfile : Profile
    {

        public DomainProfile()
        {

            #region Map
            CreateMap<RequestAluno, Aluno>();
            CreateMap<Aluno, RequestAluno>();



            #endregion
        }
    }
}
