using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using vigalileo.Services.System.Auth;

namespace vigalileo.BackendApi.Middlewares
{
    public class ViAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        public ViAuthenticationMiddleware(RequestDelegate next) => _next = next;
        public async Task Invoke(HttpContext httpContext, IJWTService jWTService)
        {
            var jwtToken = httpContext.Request.Headers["Authorization"].ToString();
            try
            {
                ValidateToken(jWTService, httpContext, jwtToken);
                await _next(httpContext);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private static void ValidateToken(IJWTService jWTService, HttpContext httpContext, string jwtToken)
        {
            try
            {
                var principal = jWTService.ValidateToken(jwtToken);
                httpContext.User = principal;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}