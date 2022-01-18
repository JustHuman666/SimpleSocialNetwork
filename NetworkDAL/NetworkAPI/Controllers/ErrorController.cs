using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetworkAPI.ErrorBuilder;
using NetworkBLL.Validation;

namespace NetworkAPI.Controllers
{
    /// <summary>
    /// Controller for error handling
    /// </summary>
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        public ActionResult Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context?.Error;

            if (exception is NetworkException)
            {
                return BadRequest(new ApiErrorBuilder(exception.Message, HttpStatusCode.BadRequest));
            }
                
            if (exception is NotFoundException)
            {
                return NotFound(new ApiErrorBuilder(exception.Message, HttpStatusCode.NotFound));
            }

            return new JsonResult(new ApiErrorBuilder(exception.Message, HttpStatusCode.InternalServerError));
        }
    }
}