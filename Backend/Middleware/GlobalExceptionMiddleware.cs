using System.Net;
using FluentValidation;
using System.Text.Json;

namespace Backend.Middleware;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;

    public GlobalExceptionMiddleware(
        RequestDelegate next,
        ILogger<GlobalExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            await HandleValidationException(context, ex);
        }
        catch (Exception ex)
        {
            await HandleGeneralException(context, ex);
        }
    }

    private static async Task HandleValidationException(
        HttpContext context,
        ValidationException ex)
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        context.Response.ContentType = "application/json";

        var errors = ex.Errors.Select(e => new
        {
            field = e.PropertyName,
            message = e.ErrorMessage
        });

        var response = new
        {
            message = "Validation failed",
            errors
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

    private async Task HandleGeneralException(
        HttpContext context,
        Exception ex)
    {
        _logger.LogError(ex, "Unhandled exception occurred");

        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";

        var response = new
        {
            message = "An unexpected error occurred"
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}