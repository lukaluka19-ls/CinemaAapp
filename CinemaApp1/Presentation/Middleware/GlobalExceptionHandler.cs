using CinemaApp1.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Presentation.Middleware
{
    internal sealed class GlobalExceptionHandler(RequestDelegate next, ILogger<GlobalExceptionHandler>logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch(Exception ex) {
                logger.LogError(ex, "Unhandeled exception occured");

                context.Response.StatusCode = ex switch
                {
                    ApplicationException => StatusCodes.Status400BadRequest,
                    UnprocessableException => StatusCodes.Status422UnprocessableEntity,
                    _ => StatusCodes.Status500InternalServerError
                };
                await context.Response.WriteAsJsonAsync(
                    new ProblemDetails
                    {
                        Type = ex.GetType().Name,
                        Title = "An Error ocured",
                        Detail = ex.Message
                    });
            }

        }

    }
}
