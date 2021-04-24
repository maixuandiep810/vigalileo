using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using vigalileo.DTOs.Common;
using vigalileo.DTOs.System.RolePermissions;
using vigalileo.DTOs.System.Users;

namespace vigalileo.Services.System.Users
{
    public interface IUserService
    {
        /// <summary>
        /// USER
        /// </summary>
        Task<ApiResult<bool>> RegisterAsync(RegisterRequest request);
        Task<ApiResult<string>> LoginAsync(LoginRequest request);
        Task<ApiResult<UserDTO>> GetByNameAsync(string username, string clientId);
        // TODO
        // UserId
        Task<ApiResult<bool>> UpdateAsync(UpdateUserRequest request, string userId);

        /// <summary>
        /// USER - ROLE
        /// </summary>
        Task<ApiResult<bool>> AddUserToRoleAsync(AddUserToRoleRequest request);
        Task<ApiResult<List<RoleDTO>>> GetRoleDTOAsync(string userId);
        Task<List<string>> GetRoleNameAsync(string userId);
        Task<ApiResult<bool>> RemoveUserFromRole(RemoveUserFromRoleRequest request);
        
        /// <summary>
        /// PERMISSION
        /// </summary>
        // Task<bool> CheckPermissionAsync(string userId, string name, string action);
    }
}