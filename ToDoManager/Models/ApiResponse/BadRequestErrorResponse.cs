using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ToDoManager.Models
{
    public class BadRequestErrorResponse : ErrorResponse
    {
        public BadRequestErrorResponse(string errorMessage) :  base (HttpStatusCode.BadRequest, errorMessage)
        {
        }

        public BadRequestErrorResponse(ModelStateDictionary modelState) : base (HttpStatusCode.BadRequest, "Please correct following errors") //TODO:This should be constant
        {
            Errors = modelState.SelectMany(x => x.Value.Errors).Select(x => x.ErrorMessage).ToList();
        }

        public List<string> Errors { get; set; }
    }
}
