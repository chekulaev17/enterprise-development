using FoodDelivery.Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Api.ErrorHandling;

/// <summary>
/// Преобразует исключения приложения в HTTP-ответы
/// </summary>
/// <param name="logger">Средство журналирования</param>
/// <param name="problemDetailsService">Служба формирования ответов об ошибках</param>
public sealed class ApiExceptionHandler(
    ILogger<ApiExceptionHandler> logger,
    IProblemDetailsService problemDetailsService) : IExceptionHandler
{
    /// <inheritdoc/>
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var isConflict = exception is ResourceConflictException;

        var statusCode = isConflict
            ? StatusCodes.Status409Conflict
            : StatusCodes.Status500InternalServerError;

        if (isConflict)
        {
            logger.LogWarning(
                exception,
                "Конфликт при выполнении {Method} {Path}",
                httpContext.Request.Method,
                httpContext.Request.Path);
        }
        else
        {
            logger.LogError(
                exception,
                "Ошибка при выполнении {Method} {Path}",
                httpContext.Request.Method,
                httpContext.Request.Path);
        }

        httpContext.Response.StatusCode = statusCode;

        await problemDetailsService.WriteAsync(new ProblemDetailsContext
        {
            HttpContext = httpContext,
            ProblemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = isConflict
                    ? "Конфликт данных"
                    : "Внутренняя ошибка сервера",
                Detail = isConflict ? exception.Message : null,
                Instance = httpContext.Request.Path.Value
            }
        });

        return true;
    }
}
