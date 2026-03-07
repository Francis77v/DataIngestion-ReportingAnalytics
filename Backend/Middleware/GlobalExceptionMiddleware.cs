using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Middleware;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        _logger.LogError(
            exception, "Exception occurred: {Message}", exception.Message);

        var (statusCode, title) = MapException(exception);

        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Detail = exception.Message
        };

        httpContext.Response.StatusCode = statusCode;

        await httpContext.Response
            .WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }

    private static (int StatusCode, string Title) MapException(Exception exception) =>
        exception switch
        {
            ArgumentNullException      => (StatusCodes.Status400BadRequest,        "Bad Request"),
            ArgumentException          => (StatusCodes.Status400BadRequest,        "Bad Request"),
            UnauthorizedAccessException => (StatusCodes.Status401Unauthorized,     "Unauthorized"),
            KeyNotFoundException       => (StatusCodes.Status404NotFound,          "Not Found"),
            NotImplementedException    => (StatusCodes.Status501NotImplemented,    "Not Implemented"),
            OperationCanceledException => (StatusCodes.Status499ClientClosedRequest, "Client Closed Request"),
            TimeoutException           => (StatusCodes.Status504GatewayTimeout,   "Gateway Timeout"),
            _                          => (StatusCodes.Status500InternalServerError, "Server Error")
        };
}