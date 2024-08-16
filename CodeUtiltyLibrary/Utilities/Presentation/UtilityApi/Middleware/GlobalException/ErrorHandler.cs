using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Utilities.Core.UtilityApplication.Exceptions.GlobalException;

namespace Utilities.Presentation.UtilityApi.Middleware.GlobalException
{
    public class ErrorHandler
    {
        private readonly RequestDelegate _next;

        public ErrorHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string message = string.Empty;
            try
            {
                await _next.Invoke(context);

                message = context.Response?.StatusCode switch
                {
                    400 => "Bad Request",
                    401 => "Unauthorized",
                    403 => "Forbidden",
                    404 => "Not Found",

                    501 => "Not Implemented",
                    502 => "Bad Gateway",
                    503 => "Service Unavailable",
                    504 => "Gateway Timeout",
                    500 => "Internal Server Error",
                    _ => "Unknown Error"
                };
            }
            catch (Exception ex)
            {
                message = ex.InnerException?.Message ?? ex.Message;
                context.Response.StatusCode = 500;
            }

            if (!context.Response.HasStarted && context.Response.StatusCode >= 400)
            {
                context.Response.ContentType = "application/json";
                var response = new ResponseExceptionModel(message, context.Response.StatusCode);
                var json = JsonConvert.SerializeObject(response);
                await context.Response.WriteAsync(json);
            }
        }


    }
}
