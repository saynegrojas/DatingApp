using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using DatingApp.API.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DatingApp.API.Middleware
{
    public class ExceptionMiddleware
    {
        // init all fields from parameter
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        // pass in RequestDelegate - what's next in middleware pipeline, keeps going up & up of middleware pipe
        // pass in ILogger - logs out our exceptions in the terminal for info
        // pass in IHostEnvironment - checks to see what env we are running in
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            // set field to param
            _next = next;
            _logger = logger;
            _env = env;
        }

        // middleware required method
        public async Task InvokeAsync(HttpContext context) {
            try {
                await _next(context);
            } catch(Exception ex) {
                // logs excepiton & a message of that exception
                _logger.LogError(ex, ex.Message);

                context.Response.ContentType = "application/json";
                // status code 500
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                
                // create a var that will be our response of env
                var response = _env.IsDevelopment()
                // in development
                    ? new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString())
                    // in production
                    : new ApiException(context.Response.StatusCode, "Internal Server Error");
                
                // send response as JSON & camelcase
                var options = new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase};

                // serialize response the way we set our options as JSON/Camelcase by calling the Serializer method on JsonSerializer
                var json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);
            }
        }
    }
}