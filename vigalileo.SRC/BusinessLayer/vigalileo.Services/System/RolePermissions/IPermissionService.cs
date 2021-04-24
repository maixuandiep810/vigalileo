using System.Threading.Tasks;
using vigalileo.Data.Entities;

namespace vigalileo.Services.System.RolePermissions
{
    public interface IPermissionService
    {
        Task<bool> IsAuthenticatedRouteAsync(string pathRegex, string action);

        Task<Permission> FindRoutePermissionAsync(
                            string pathRegex, string action,
                            bool isCheckAuthenticatedRoute = false);
        Task<Permission> FindEntityPermissionAsync(string entityName, string action);
    }
}


// Task<bool> IsAuthenticatedRouteAsync(string pathRegex, string action);
// Task<bool> IsAuthorizedRouteAsync(string pathRegex, string action);