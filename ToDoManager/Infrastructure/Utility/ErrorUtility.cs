using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoManager.Models;

namespace ToDoManager.Infrastructure
{
    public class ErrorUtility
    {
        public static BadRequestObjectResult BadRequest(string errorMessage)
        {
            return new BadRequestObjectResult(new BadRequestErrorResponse(errorMessage));
        }
    }
}
