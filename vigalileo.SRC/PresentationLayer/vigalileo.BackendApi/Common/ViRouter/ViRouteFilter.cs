using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;

namespace vigalileo.BackendApi.Common.ViRouter
{
    public class ViRouteFilter
    {
        public static bool FilterRoutes(HttpContext httpContext, ViRoute viRoute)
        {
            var isRightPath = Regex.IsMatch(httpContext.Request.Path, viRoute.PathRegex);
            var isRightMethod = httpContext.Request.Method == viRoute.Method;
            var isRightRoute = isRightPath && isRightMethod;
            return isRightRoute;
        }

        public static bool FilterRoutes(HttpContext httpContext, ViRoute[] viRouteArray)
        {
            foreach (var route in viRouteArray)
            {
                if (FilterRoutes(httpContext, route))
                {
                    return true;
                }
            }
            return false;
        }
    }
}