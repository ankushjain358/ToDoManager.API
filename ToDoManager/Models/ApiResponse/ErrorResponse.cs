using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ToDoManager.Models
{
    public class ErrorResponse
    {
        public ErrorResponse(HttpStatusCode statusCode, string message)
        {
            StatusCode = statusCode;
            ErrorMessage = message;
        }

        public HttpStatusCode StatusCode { get; set; }

        public string ErrorMessage { get; set; }
    }
}
