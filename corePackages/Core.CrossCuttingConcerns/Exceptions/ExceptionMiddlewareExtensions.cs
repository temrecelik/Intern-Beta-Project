using Microsoft.AspNetCore.Builder;

namespace Core.CrossCuttingConcerns.Exceptions;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureExceptionMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }
}