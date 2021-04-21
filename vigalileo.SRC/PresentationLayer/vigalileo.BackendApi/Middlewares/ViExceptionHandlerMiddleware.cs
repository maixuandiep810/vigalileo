using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace vigalileo.BackendApi.Middlewares
{
    public class ViExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ViExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionMessageAsync(httpContext, ex);
                // await HandleExceptionMessageAsync(context, ex).ConfigureAwait(false);
            }
        }

        private static async Task HandleExceptionMessageAsync(HttpContext httpContext, Exception exception)
        {
            await httpContext.Response.WriteAsync("ERROR");
        }
    }
}