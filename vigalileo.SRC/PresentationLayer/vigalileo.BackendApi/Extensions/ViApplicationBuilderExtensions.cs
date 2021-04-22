using Microsoft.AspNetCore.Builder;
using vigalileo.BackendApi.Middlewares;
using vigalileo.BackendApi.Common.ViRouter;
using Microsoft.AspNetCore.Http;

namespace vigalileo.BackendApi.Extensions
{
    public static class ViApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseViAuthentication(this IApplicationBuilder app)
        {
            app.UseWhen(ViRouteFilter.FilterAuthenticationRoutes,
                app => app.UseViAuthentication()
            );  
            return app.UseMiddleware<ViAuthenticationMiddleware>();
        }

        public static IApplicationBuilder UseViExceptionHandler(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ViExceptionHandlerMiddleware>();
        }
    }
}