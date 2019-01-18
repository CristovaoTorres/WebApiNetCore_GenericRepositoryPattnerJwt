using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApiNetCore_GenericRepositoryPattnerJwt.Controllers
{

    [Route("api/[controller]")/*, Authorize*/]
    public class ValuesController : Controller
    {

        [HttpGet()]
        public IActionResult Index()
        {
            return View();
        }
    }
}