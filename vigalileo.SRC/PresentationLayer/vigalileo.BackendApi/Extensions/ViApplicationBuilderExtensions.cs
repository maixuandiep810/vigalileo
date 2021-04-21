using Microsoft.AspNetCore.Builder;
using vigalileo.BackendApi.Middlewares;

namespace vigalileo.BackendApi.Extensions
{
    public static class ViApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseViAuthentication(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ViAuthenticationMiddleware>();
        }

        public static IApplicationBuilder UseViExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ViExceptionHandlerMiddleware>();
        }
    }
}