using System.Collections.Generic;
using System.Threading.Tasks;
using vigalileo.Data.Entities;
using vigalileo.DTOs.Common;
using vigalileo.DTOs.System.RolePermissions;

namespace vigalileo.Services.System.RolePermissions
{
    public interface IRoleService
    {
        Task<ApiResult<bool>> AddRoleAsync(AddRoleRequest request);
        Task<ApiResult<bool>> AddPermissionToRoleAsync(AddPermissionToRoleRequest request);

        List<Permission> GetPermissionList(ApplicationRole role);
        List<Permission> GetPermissionList(List<ApplicationRole> roles);

        Task<List<string>> GetRoleNameHasPermission(string pathRegex, string action);
    }
}