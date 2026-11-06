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
        var (statusCode, title) = exception switch
        {
            ResourceConflictException => (
                StatusCodes.Status409Conflict,
                "Конфликт данных"),
            InvalidReferenceException => (
                StatusCodes.Status422UnprocessableEntity,
                "Некорректная связь между сущностями"),
            _ => (
                StatusCodes.Status500InternalServerError,
                "Внутренняя ошибка сервера")
        };

        if (statusCode == StatusCodes.Status500InternalServerError)
        {
            logger.LogError(
                exception,
                "Ошибка при выполнении {Method} {Path}",
                httpContext.Request.Method,
                httpContext.Request.Path);
        }
        else
        {
            logger.LogWarning(
                exception,
                "Отклонён запрос {Method} {Path}, код ответа: {StatusCode}",
                httpContext.Request.Method,
                httpContext.Request.Path,
                statusCode);
        }

        httpContext.Response.StatusCode = statusCode;

        await problemDetailsService.WriteAsync(new ProblemDetailsContext
        {
            HttpContext = httpContext,
            ProblemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = title,
                Detail = statusCode == StatusCodes.Status500InternalServerError
                    ? null
                    : exception.Message,
                Instance = httpContext.Request.Path.Value
            }
        });

        return true;
    }
}
