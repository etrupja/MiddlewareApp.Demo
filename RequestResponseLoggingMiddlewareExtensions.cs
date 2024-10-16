namespace MiddlewareApp.Demo;

public static class RequestResponseLoggingMiddlewareExtensions
{
    public static IApplicationBuilder UseRequestResponseLogging(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestResponseLoggingMiddleware>();
    }
}

public class RequestResponseLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestResponseLoggingMiddleware> _logger;

    public RequestResponseLoggingMiddleware(RequestDelegate next, ILogger<RequestResponseLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        // Log when the middleware is triggered
        Console.WriteLine("Middleware Triggered: Request incoming");

        _logger.LogInformation("Request Path: {Path}", context.Request.Path);
        var startTime = DateTime.UtcNow;

        // Call the next middleware in the pipeline
        await _next(context);

        var executionTime = DateTime.UtcNow - startTime;
        _logger.LogInformation("Response Status Code: {StatusCode}", context.Response.StatusCode);
        _logger.LogInformation("Execution Time: {ExecutionTime} ms", executionTime.TotalMilliseconds);
    }
}
