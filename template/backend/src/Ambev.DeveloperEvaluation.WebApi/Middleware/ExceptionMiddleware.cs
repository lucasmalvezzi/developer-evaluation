using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.WebApi.Common;
using FluentValidation;
using System;
using System.Text.Json;

namespace Ambev.DeveloperEvaluation.WebApi.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                await HandleValidationExceptionAsync(context, ex);
            }catch(KeyNotFoundException ex)
            {
                await HandleKeyNotFoundExceptionAsync(context, ex);
            }

        }

        private static Task HandleKeyNotFoundExceptionAsync(HttpContext context, KeyNotFoundException ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
          
            var response = new ApiResponse
            {
                Success = false,
                Message = ex.Message,
                Errors = []
            };
            return context.Response.WriteAsync(JsonSerializer.Serialize(response, jsonOptions));

        }

        private static Task HandleValidationExceptionAsync(HttpContext context, ValidationException exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var response = new ApiResponse
            {
                Success = false,
                Message = "Validation Failed",
                Errors = exception.Errors
                    .Select(error => (ValidationErrorDetail)error)
            };
            return context.Response.WriteAsync(JsonSerializer.Serialize(response, jsonOptions));
        }
    }
}
