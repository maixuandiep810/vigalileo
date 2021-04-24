using Microsoft.AspNetCore.Builder;
using vigalileo.BackendApi.Middlewares;
using Microsoft.AspNetCore.Http;

namespace vigalileo.BackendApi.Extensions
{
    public static class ViApplicationBuilderExtensions
    {


        public static IApplicationBuilder UseViRBAC(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ViRBACMiddleware>();
        }

        public static IApplicationBuilder UseViExceptionHandler(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ViExceptionHandlerMiddleware>();
        }
    }
}