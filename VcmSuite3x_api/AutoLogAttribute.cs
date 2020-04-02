
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace VcmSuite3x_api
{
    public class AutoLogAttribute : TypeFilterAttribute
    {
        public AutoLogAttribute() : base(typeof(AutoLogActionFilterImpl))
        {

        }

        private class AutoLogActionFilterImpl : IActionFilter
        {
            private readonly ILogger _logger;
            public AutoLogActionFilterImpl(ILoggerFactory loggerFactory)
            {
                _logger = loggerFactory.CreateLogger<AutoLogAttribute>();
            }

            public void OnActionExecuting(ActionExecutingContext context)
            {

                Debug.Print("/*/*/*/*//*/*/*/*/*/*/*/*///*/*/*/");
                //Loga os Request
                // perform some business logic work
            }

            public void OnActionExecuted(ActionExecutedContext context)
            {
                Debug.Print("/*/*/*/*//*/*/*/*/*/*/*/*///*/*/*/");
                //Loga os retornos
                //TODO: log body content and response as well
                _logger.LogDebug($"path: {context.HttpContext.Request.Path}");
            }
        }
    }
}
