
using System.Diagnostics;

namespace WorldTravel.API.Middlewares;

public class RequestTimeLoggerMiddleware(ILogger<RequestTimeLoggerMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var timer = Stopwatch.StartNew();
        await next.Invoke(context);
        timer.Stop();

        // log any requests that take longer than 5 seconds
        if (timer.ElapsedMilliseconds > 5000)
        {
            logger.LogInformation($"Request [{context.Request.Method}] at {context.Request.Path} took {timer.ElapsedMilliseconds} ms");
        }
    }
}
