using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using vigalileo.Data.UnitOfWorkPattern;
using System.Linq;
using vigalileo.Data.Entities;

namespace vigalileo.Services.System.RolePermissions
{
    public class PermissionService : IPermissionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public PermissionService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }



        /*
        *
        *
        *
        *
        *
        *
        */


        /*
        *
        *
        *
        *
        *
        *
        */

        public async Task<bool> IsAuthenticatedRouteAsync(string pathRegex, string action)
        {
            var routePermission = await FindRoutePermissionAsync(pathRegex, action, true);
            if (routePermission != null)
            {
                return true;
            }
            return false;
        }

        public async Task<Permission> FindRoutePermissionAsync(
                            string pathRegex, string action,
                            bool isCheckAuthenticatedRoute = false)
        {
            var routePermissionList = await _unitOfWork.PermissionRepository.GetRoutePermissions();
            if (routePermissionList != null)
            {
                var routePerm = routePermissionList.Find(x =>
                    {
                        var isRightPath = Regex.IsMatch(pathRegex, x.RoutePermission.PathRegex);
                        var isRightMethod = action == x.RoutePermission.Action;
                        var isAuthenticatedRoute = x.RoutePermission.IsAuthenticatedRoute;

                        var isRightRoute = isRightPath && isRightMethod && (isCheckAuthenticatedRoute == false ? true : isAuthenticatedRoute);

                        return isRightRoute;
                    });
                return routePerm;
            }
            return null;
        }

        public async Task<Permission> FindEntityPermissionAsync(string entityName, string action)
        {
            var entityPermissionList = await _unitOfWork.PermissionRepository.GetRoutePermissions();
            if (entityPermissionList != null)
            {
                var entityPermission = entityPermissionList.Find(x =>
                {
                    return x.EntityPermission.EntityName == entityName && x.EntityPermission.Action == action;
                });
                return entityPermission;
            }
            return null;
        }
    }
}



// public async Task<bool> IsAuthenticatedRoute_ForAuthenticatedClientAsync(string pathRegex, string action)
// {
//     var routePermission = await FindRoutePermissionAsync(pathRegex, action, true, true);
//     if (routePermission != null)
//     {
//         return true;
//     }
//     return false;
// }

// public async Task<bool> IsAuthorizedRouteAsync(string pathRegex, string action)
// {
//     var routePermission = await FindRoutePermissionAsync(pathRegex, action, true, true, true);
//     if (routePermission != null)
//     {
//         return true;
//     }
//     return false;
// }