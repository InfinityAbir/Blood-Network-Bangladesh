using System.Net;
using System.Text.Json;
using BloodNetwork.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace BloodNetwork.Api.Middleware;

public class GlobalExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

    public GlobalExceptionHandlingMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlingMiddleware> logger)
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
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception occurred");
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        var (statusCode, message, errors) = exception switch
        {
            NotFoundException notFound => (
                HttpStatusCode.NotFound,
                notFound.Message,
                Array.Empty<object>()
            ),
            ValidationException validation => (
                HttpStatusCode.BadRequest,
                validation.Message,
                Array.Empty<object>()
            ),
            DomainException domain => (
                HttpStatusCode.BadRequest,
                domain.Message,
                Array.Empty<object>()
            ),
            _ => (
                HttpStatusCode.InternalServerError,
                "An unexpected error occurred. Please try again later.",
                Array.Empty<object>()
            )
        };

        context.Response.StatusCode = (int)statusCode;

        var response = new
        {
            success = false,
            message,
            errors,
            traceId = context.TraceIdentifier
        };

        var jsonOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        await context.Response.WriteAsync(JsonSerializer.Serialize(response, jsonOptions));
    }
}
