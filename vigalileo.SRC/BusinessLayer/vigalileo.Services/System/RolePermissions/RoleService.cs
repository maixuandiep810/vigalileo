using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using vigalileo.Data.Entities;
using vigalileo.Data.UnitOfWorkPattern;
using vigalileo.DTOs.Common;
using vigalileo.DTOs.System.RolePermissions;
using vigalileo.Utilities.Constants;

namespace vigalileo.Services.System.RolePermissions
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IPermissionService _permissionService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public RoleService(
            RoleManager<ApplicationRole> roleManager,
            IPermissionService permissionService,
            IUnitOfWork unitOfWork,
            IConfiguration configuration)
        {
            _roleManager = roleManager;
            _permissionService = permissionService;
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }


        ///
        ///     ROLE
        /// 

        /// <summary>
        /// 
        /// C
        /// 
        /// ADD ROLE
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ApiResult<bool>> AddRoleAsync(AddRoleRequest request)
        {
            var apiResult = new ApiResult<bool>(false);
            var role = await _roleManager.FindByNameAsync(request.Name);
            if (role != null)
            {
                apiResult.SetResult((int)ApiResultConstants.CODE.ROLE_EXISTS_E, false, false,
                    ApiResultConstants.MESSAGE(ApiResultConstants.CODE.ROLE_EXISTS_E));
                return apiResult;
            }
            role = new ApplicationRole()
            {
                Name = request.Name
            };
            var createResult = await _roleManager.CreateAsync(role);
            if (createResult.Succeeded)
            {
                apiResult.SetResult((int)ApiResultConstants.CODE.SUCCESSFULLY_CREATING_ROLE_S, true, true,
                    ApiResultConstants.MESSAGE(ApiResultConstants.CODE.SUCCESSFULLY_CREATING_ROLE_S));
                return apiResult;
            }
            else
            {
                apiResult.SetResult((int)ApiResultConstants.CODE.ERROR, false, false,
                    ApiResultConstants.MESSAGE(ApiResultConstants.CODE.ERROR));
                return apiResult;
            }
        }

        /// <summary>
        /// 
        /// C
        /// 
        /// Add ROLE To Permission
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ApiResult<bool>> AddPermissionToRoleAsync(AddPermissionToRoleRequest request)
        {
            var apiResult = new ApiResult<bool>(false);
            var role = await _roleManager.FindByIdAsync(request.ApplicationRoleId.ToString());
            var permission = await _unitOfWork.PermissionRepository.GetByIdAsync(request.PermissionId);
            if (role == null || permission == null)
            {
                apiResult.SetResult((int)ApiResultConstants.CODE.ERROR, false, false,
                    ApiResultConstants.MESSAGE(ApiResultConstants.CODE.ERROR));
                return apiResult;
            }
            var permissionInRole = new PermissionInRole()
            {
                ApplicationRoleId = request.ApplicationRoleId,
                PermissionId = request.PermissionId
            };
            await _unitOfWork.PermissionInRoleRepository.AddAsync(permissionInRole);
            await _unitOfWork.CommitAsync();
            apiResult.SetResult((int)ApiResultConstants.CODE.SUCCESS, true, true,
                ApiResultConstants.MESSAGE(ApiResultConstants.CODE.SUCCESS));
            return apiResult;
        }



        ///
        ///     PERMISSION 
        /// 

        /// <summary>
        /// 
        /// R
        /// 
        /// A Role - Has Permission
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public List<Permission> GetPermissionList(ApplicationRole role)
        {
            var permissionsOfARole = role.PermissionInRoles.Select(x => x.Permission).ToList();
            return permissionsOfARole;
        }

        /// <summary>
        /// 
        /// R
        /// 
        /// Roles - Has Permission
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public List<Permission> GetPermissionList(List<ApplicationRole> roles)
        {
            var permissionList = new List<Permission>();
            foreach (var role in roles)
            {
                var permissionListOfARole = GetPermissionList(role);
                permissionList.AddRange(permissionListOfARole);
            }
            return permissionList;
        }


        public async Task<bool> HasRoutePermission(ApplicationRole role, string pathRegex, string action)
        {
            var routePermission = await _permissionService.FindRoutePermissionAsync(pathRegex, action);
            if (routePermission == null)
            {
                return false;
            }
            var permissionList = GetPermissionList(role);
            foreach (var perm in permissionList)
            {
                if (perm.Id == routePermission.Id)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> HasRoutePermission(List<ApplicationRole> roleList, string pathRegex, string action)
        {
            foreach (var role in roleList)
            {
                if (await HasRoutePermission(role, pathRegex, action))
                {
                    return true;
                }
            }
            return false;
        }


        public async Task<List<ApplicationRole>> GetRoleHasPermissionAsync(Permission permisison)
        {
            var permissionInRoleList = await _unitOfWork.PermissionInRoleRepository.FindAsync(x => x.PermissionId == permisison.Id);
            if (permissionInRoleList == null)
            {
                return null;
            }
            var roleList = new List<ApplicationRole>();
            foreach (var permissionInRole in permissionInRoleList)
            {
                var role = await _roleManager.FindByIdAsync(permissionInRole.ApplicationRoleId.ToString());
                if (role != null)
                {
                    roleList.Add(role);
                }
            }
            return roleList;
        }


        public async Task<List<string>> GetRoleNameHasPermission(string pathRegex, string action)
        {
            var permission = await _permissionService.FindRoutePermissionAsync(pathRegex, action);
            if (permission == null)
            {
                return null;
            }
            var roleList = await GetRoleHasPermissionAsync(permission);
            var roleNameList = roleList.Select(x => x.Name).ToList();
            return roleNameList;
        }


    }
}

// public async Task<List<ApplicationRole>> GetRoleHasPermissionListAsync(List<Permission> permisisonList)
// {
//     var roleList = new List<ApplicationRole>();
//     foreach (var permission in permisisonList)
//     {
//         var role = await GetRoleHasPermissionAsync(permission);
//         if (role != null)
//         {
//             roleList.AddRange(role);
//         }
//     }
//     return roleList;
// }