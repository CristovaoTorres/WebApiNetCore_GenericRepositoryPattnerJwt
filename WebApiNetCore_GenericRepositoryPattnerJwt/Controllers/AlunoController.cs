using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiNetCore_GenericRepositoryPattnerJwt.Core.Interface;
using WebApiNetCore_GenericRepositoryPattnerJwt.Core.Models;
using WebApiNetCore_GenericRepositoryPattnerJwt.Models;

namespace WebApiNetCore_GenericRepositoryPattnerJwt.Controllers
{

    [Route("api/[controller]")/*, Authorize*/]
    public class AlunoController : Controller
    {
        //private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfw;

        public AlunoController(IUnitOfWork unitOfw/*, IMapper mapper*/)
        {
            _unitOfw = unitOfw;
            //_mapper = mapper;
        }

        [Route("AddOrUpdate")]
        [HttpPost]
        public IActionResult Create([FromBody]RequestAluno model)
        {

            if (_unitOfw.AlunoRepository.Count(y => y.Nome == model.Nome) == 0)
            {
                //Aluno tobeSave = _mapper.Map<Aluno>(model);
                _unitOfw.AlunoRepository.Insert(new Aluno());
            }
            else
            {
                BaseViewModel<string> jaExiste = new BaseViewModel<string>("Aluno Já existe!");
                return Ok(jaExiste);
            }

            

            BaseViewModel<RequestAluno> baseObj = new BaseViewModel<RequestAluno>(model, "Aluno Saved Successfully!", "");
            return Ok(baseObj);
        }
    }
}