using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace ContactManagement.Api.WebApiHelpers
{
    public class GlobalExceptionMidleware
    {
        private readonly RequestDelegate next;

        private readonly ILogger<GlobalExceptionMidleware> logger;
        //private readonly IHostingEnvironment env;
        
        public GlobalExceptionMidleware(RequestDelegate next, ILogger<GlobalExceptionMidleware> logger)
        {
            this.next = next;
            this.logger = logger;
           // this.env = env;
        }

        public async Task Invoke(HttpContext context)
        {
            var builder = WebApplication.CreateBuilder();
            var isDevelopment = builder.Environment.IsDevelopment();
            try
            {
                await next.Invoke(context);
            }
            catch (Exception ex)
            {
                ApiError response;
                HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
                string message;
                var exceptionType = ex.GetType();

                if (exceptionType == typeof(UnauthorizedAccessException))
                {
                    statusCode = HttpStatusCode.Forbidden;
                    message = "your are not authorized";
                }
                else
                {
                    statusCode = HttpStatusCode.InternalServerError;
                    message = "Some unknown error occured";
                }
                if (builder.Environment.IsDevelopment())
                {
                    response = new ApiError((int)statusCode, ex.Message, ex.StackTrace.ToString());
                }
                else
                {
                    response = new ApiError((int)statusCode, message);
                }
                context.Response.StatusCode = (int)statusCode;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(response.ToString());
            }

        }
    }
}
