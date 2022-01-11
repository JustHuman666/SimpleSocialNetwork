using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
                return BadRequest($"{exception.Message}. Status code: {HttpStatusCode.BadRequest}");
            }
                
            if (exception is NotFoundException)
            {
                return NotFound($"{exception.Message}. Status code: {HttpStatusCode.NotFound}");
            }

            return StatusCode(500, $"Something went wrog. Status code: {HttpStatusCode.InternalServerError}");
        }
    }
}