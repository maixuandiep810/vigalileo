// using System.Linq;
// using System.Security.Claims;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Http;
// using vigalileo.Services.System.Auth;

// namespace vigalileo.BackendApi.Middlewares
// {
//     public class ViGetAuthenticationMiddleware
//     {
//         private readonly RequestDelegate _next;
//         public ViGetAuthenticationMiddleware(RequestDelegate next) => _next = next;
//         public async Task Invoke(HttpContext httpContext, IJWTService jWTService)
//         {
//             var jwtToken = httpContext.Request.Headers["Authorization"].ToString();
//             try
//             {
//                 ValidateToken(jWTService, httpContext, jwtToken);
//                 await _next(httpContext);
//             }
//             catch (System.Exception)
//             {
//                 httpContext.Items["ClientId"] = "";
//                 await _next(httpContext);
//             }
//         }


//     }
// }