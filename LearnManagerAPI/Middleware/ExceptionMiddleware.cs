using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;

namespace LearnManagerAPI.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception");
                var env = httpContext.RequestServices.GetService<IWebHostEnvironment>();
                await HandleExceptionAsync(httpContext, ex, env?.IsDevelopment() ?? false);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception, bool isDevelopment)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var message = isDevelopment ? exception.Message : "An unexpected error occurred.";
            var response = new { message };
            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
