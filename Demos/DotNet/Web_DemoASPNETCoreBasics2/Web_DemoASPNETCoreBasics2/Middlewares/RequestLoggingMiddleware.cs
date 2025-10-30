using Microsoft.AspNetCore.Http;
using System.Diagnostics;

namespace Web_DemoASPNETCoreBasics2.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();
            // Call the next middleware in the pipeline
            await _next(context);
            stopwatch.Stop();
            var processingTime = stopwatch.ElapsedMilliseconds;
            var method = context.Request.Method;
            var path = context.Request.Path;
            var statusCode = context.Response.StatusCode;
            Console.WriteLine($"[{DateTime.Now}] {method} {path} responded {statusCode} in {processingTime} ms");
        }
    }

    public static class RequestLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLoggingMiddleware>();
        }
    }
}
