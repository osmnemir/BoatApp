using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using N.Core.DTOs;
using N.Service.Exceptions;
using System.Text.Json;

internal static class UseCustomExceptionHandlerHelpers
{

    public static void UserCustomException(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(config =>
        {

            config.Run(async context =>
            {
                context.Response.ContentType = "application/json";

                var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                var statusCode = exceptionFeature.Error switch
                {
                    ClientSideException => 400,
                    NotFoundExcepiton => 404,
                    _ => 500
                };
                context.Response.StatusCode = statusCode;


                var response = CustomResponseDto<NoContentDto>.Fail(statusCode, exceptionFeature.Error.Message);


                await context.Response.WriteAsync(JsonSerializer.Serialize(response));

            });

        });
    }
}