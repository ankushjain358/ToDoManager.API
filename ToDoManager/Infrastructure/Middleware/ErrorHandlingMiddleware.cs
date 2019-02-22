using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ToDoManager.Models;

namespace ToDoManager.Infrastructure.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        //private readonly ILogger<ErrorHandlingMiddleware> _logger;

        //public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorWrappingMiddleware> logger)
        //{
        //    _next = next;
        //    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        //}

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string errorMessage = string.Empty;

            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                //_logger.LogError(EventIds.GlobalException, ex, ex.Message);
                errorMessage = ex.Message;
                context.Response.StatusCode = 500;
            }

            if (!context.Response.HasStarted)
            {
                context.Response.ContentType = "application/json";

                //HttpStatusCode statusCode = (HttpStatusCode)context.Response.StatusCode;

                //switch (statusCode)
                //{
                //    case HttpStatusCode.BadRequest:
                //        break;
                //    case HttpStatusCode.BadRequest:
                //        break;
                //    case HttpStatusCode.BadRequest:
                //        break;
                //    default:
                //}

                var response = new ErrorResponse((HttpStatusCode)context.Response.StatusCode, errorMessage);

                var json = JsonConvert.SerializeObject(response, new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

                await context.Response.WriteAsync(json);
            }
        }
    }
}
