using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NetworkAPI.ErrorBuilder
{
    /// <summary>
    /// Class for returning errors by api
    /// </summary>
    public class ApiErrorBuilder
    {
        public string Message { get; }
        public HttpStatusCode StatusCode { get; }

        /// <summary>
        /// Constructor for creating error object with given parametrs
        /// </summary>
        /// <param name="message">The message of sent exception</param>
        /// <param name="code">The status code of exception</param>
        public ApiErrorBuilder(string message, HttpStatusCode code)
        {
            Message = message;
            StatusCode = code;
        }
    }
}
