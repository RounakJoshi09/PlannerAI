using System.Net;
using Contracts;
using Entities.ErrorModel;
using Microsoft.AspNetCore.Diagnostics;
using PlannerAI.Entities;

public static class ExceptionMiddlewareExtension
{

    public static void ConfigureMiddlewareException(this WebApplication app, ILoggerManager loggerManager)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                if (contextFeature != null)
                {
                    context.Response.StatusCode = contextFeature.Error switch
                    {
                        NotFoundException => (int)HttpStatusCode.NotFound,
                        _ => (int)HttpStatusCode.InternalServerError
                    };

                    loggerManager.LogError($"ERROR : {contextFeature.Error}");
                    await context.Response.WriteAsync(new ErrorDetails
                    {
                        StatusCode = context.Response.StatusCode,
                        ErrorMessage = contextFeature.Error.Message
                    }.ToString());
                }
            });

        });
    }

}