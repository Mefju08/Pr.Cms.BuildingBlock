using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Pr.Cms.BuildingBlock.Core.Exceptions;
using System.Net;
using System.Text.Json;

namespace Pr.Cms.BuildingBlock.Infrastructure.Exceptions
{
    internal sealed class ExceptionHandlerMiddleware(
        ILogger<ExceptionHandlerMiddleware> logger,
        IHostEnvironment environment) : IMiddleware
    {
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception occurred while processing the request");
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var errorResponse = CreateErrorResponse(exception);

            var jsonResponse = JsonSerializer.Serialize(errorResponse, JsonOptions);
            context.Response.StatusCode = errorResponse.StatusCode;

            await context.Response.WriteAsync(jsonResponse);
        }
        private ErrorResponse CreateErrorResponse(Exception exception)
        {
            return exception switch
            {
                InvalidValueException invalidValueEx => new ErrorResponse(
                    StatusCode: (int)HttpStatusCode.BadRequest,
                    Title: "Invalid Value",
                    Detail: invalidValueEx.Message
                ),
                NotFoundException notFoundEx => new ErrorResponse(
                    StatusCode: (int)HttpStatusCode.NotFound,
                    Title: "Resource Not Found",
                    Detail: notFoundEx.Message
                ),
                ConflictException conflictEx => new ErrorResponse(
                    StatusCode: (int)HttpStatusCode.Conflict,
                    Title: "Resource Conflict",
                    Detail: conflictEx.Message
                ),
                ForbiddenException forbiddenEx => new ErrorResponse(
                    StatusCode: (int)HttpStatusCode.Forbidden,
                    Title: "Forbidden Access",
                    Detail: forbiddenEx.Message
                ),
                BaseException baseEx => new ErrorResponse(
                    StatusCode: (int)HttpStatusCode.BadRequest,
                    Title: "Application Error",
                    Detail: baseEx.Message
                ),
                _ => new ErrorResponse(
                    StatusCode: (int)HttpStatusCode.InternalServerError,
                    Title: "Internal Server Error",
                    Detail: environment.IsDevelopment() ? exception.Message : "An unexpected error occurred."
                )
            };
        }
        private static string GetTraceId()
        {
            return System.Diagnostics.Activity.Current?.Id ?? Guid.NewGuid().ToString();
        }
    }
}
