namespace Practical11.Middleware;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        _logger.LogInformation("Request: {Method} {Path}", context.Request.Method, context.Request.Path);
        try { await _next(context); }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled error for {Path}", context.Request.Path);
            if (!context.Response.HasStarted)
            {
                context.Response.Clear();
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(new { error = "An unexpected server error occurred." });
            }
        }
        _logger.LogInformation("Response: {StatusCode}", context.Response.StatusCode);
    }
}
