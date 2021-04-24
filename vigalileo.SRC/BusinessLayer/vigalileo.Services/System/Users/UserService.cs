using System;
using vigalileo.DTOs.System.Users;
using vigalileo.DTOs.Common;
using vigalileo.DTOs.System.RolePermissions;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using vigalileo.Data.Entities;
using vigalileo.Utilities.Constants;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using vigalileo.Data.UnitOfWorkPattern;
using vigalileo.Services.System.RolePermissions;

namespace vigalileo.Services.System.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRoleService _roleService;
        private readonly IConfiguration _configuration;

        public UserService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager,
            IUnitOfWork unitOfWork,
            IRoleService roleService,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
            _roleManager = roleManager;
            _configuration = configuration;
        }



        ///
        ///     USER
        /// 

        /// <summary>
        /// 
        /// C
        /// 
        /// REGISTER a Account 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ApiResult<bool>> RegisterAsync(RegisterRequest request)
        {
            var apiResult = new ApiResult<bool>(false);
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user != null || await _userManager.FindByEmailAsync(request.Email) != null)
            {
                apiResult.SetResult((int)ApiResultConstants.CODE.USERNAME_PASSWORD_EXISTS_E, false, false,
                    ApiResultConstants.MESSAGE(ApiResultConstants.CODE.USERNAME_PASSWORD_EXISTS_E));
                return apiResult;
            }

            user = new ApplicationUser()
            {
                Email = request.Email,
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName
            };
            var createResult = await _userManager.CreateAsync(user, request.Password);
            if (createResult.Succeeded)
            {
                apiResult.SetResult((int)ApiResultConstants.CODE.SUCCESSFULLY_REGISTER_S, true, true,
                    ApiResultConstants.MESSAGE(ApiResultConstants.CODE.SUCCESSFULLY_REGISTER_S));
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
        /// R
        /// 
        /// LOGIN with Username - Password
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ApiResult<string>> LoginAsync(LoginRequest request)
        {
            var apiResult = new ApiResult<string>("");
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null || (await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true)).Succeeded == false)
            {
                apiResult.SetResult((int)ApiResultConstants.CODE.USERNAME_PASSWORD_EXISTS_E, false, "",
                    ApiResultConstants.MESSAGE(ApiResultConstants.CODE.USERNAME_PASSWORD_EXISTS_E));
                return apiResult;
            }
            // var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim("Id", user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim("DuXoNem", user.UserName)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration[ConfigKeyConstants.TOKENS_KEY]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration[ConfigKeyConstants.TOKENS_ISSUER],
                _configuration[ConfigKeyConstants.TOKENS_ISSUER],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);










            var roleNames = await _userManager.GetRolesAsync(user);
            var roles = new List<ApplicationRole>();
            foreach (var roleName in roleNames)
            {
                var role = await _roleManager.FindByNameAsync(roleName);
                roles.Add(role);
            }










            apiResult.SetResult(
                (int)ApiResultConstants.CODE.SUCCESS, true, jwtToken,
                ApiResultConstants.MESSAGE(ApiResultConstants.CODE.SUCCESS));
            return apiResult;
        }

        /// <summary>
        /// 
        /// R
        /// 
        /// GET UserDTO BY ID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<ApiResult<UserDTO>> GetByNameAsync(string username, string clientId)
        {
            var result = new ApiResult<UserDTO>(new UserDTO());
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                result.SetResult((int)ApiResultConstants.CODE.CLIENT_ERROR, false, null,
                    ApiResultConstants.MESSAGE(ApiResultConstants.CODE.CLIENT_ERROR));
                return result;
            }
            var userDTO = new UserDTO();
            if (user.Id.ToString() == clientId)
            {
                userDTO = GetUserDTO_Full(user);
            }
            else
            {
                userDTO = GetUserDTO(user);
            }
            result.SetResult((int)ApiResultConstants.CODE.SUCCESS, true, userDTO,
                ApiResultConstants.MESSAGE(ApiResultConstants.CODE.SUCCESS));
            return result;
        }

        /// <summary>
        /// 
        /// U
        /// 
        /// UPDATE User
        /// </summary>
        /// <param name="request"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<ApiResult<bool>> UpdateAsync(UpdateUserRequest request, string userId)
        {
            var apiResult = new ApiResult<bool>(false);
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                apiResult.SetResult((int)ApiResultConstants.CODE.ERROR, false, false,
                    ApiResultConstants.MESSAGE(ApiResultConstants.CODE.ERROR));
                return apiResult;
            }

            user.Email = request.Email;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            var createResult = await _userManager.UpdateAsync(user);
            if (createResult.Succeeded)
            {
                apiResult.SetResult((int)ApiResultConstants.CODE.SUCCESS, true, true,
                    ApiResultConstants.MESSAGE(ApiResultConstants.CODE.SUCCESS));
                return apiResult;
            }
            else
            {
                apiResult.SetResult((int)ApiResultConstants.CODE.ERROR, false, false,
                    ApiResultConstants.MESSAGE(ApiResultConstants.CODE.ERROR));
                return apiResult;
            }
        }

        // TODO
        // Todo: Update Password.
        // Todo: DELETE account = disable



        ///
        ///     USER - ROLE
        /// 

        /// <summary>
        /// 
        /// C
        /// 
        /// Add Role to User
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ApiResult<bool>> AddUserToRoleAsync(AddUserToRoleRequest request)
        {
            var apiResult = new ApiResult<bool>(false);
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            var role = await _roleManager.FindByIdAsync(request.RoleId.ToString());
            if (user == null || role == null)
            {
                apiResult.SetResult((int)ApiResultConstants.CODE.ERROR, false, false,
                    ApiResultConstants.MESSAGE(ApiResultConstants.CODE.ERROR));
                return apiResult;
            }
            var addResult = await _userManager.AddToRoleAsync(user, role.Name);
            if (addResult.Succeeded)
            {
                apiResult.SetResult((int)ApiResultConstants.CODE.SUCCESS, true, true,
                    ApiResultConstants.MESSAGE(ApiResultConstants.CODE.SUCCESS));
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
        /// R
        /// 
        /// User - Has Role
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<ApiResult<List<RoleDTO>>> GetRoleDTOAsync(string userId)
        {
            var result = new ApiResult<List<RoleDTO>>(new List<RoleDTO>());
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                result.SetResult((int)ApiResultConstants.CODE.CLIENT_ERROR, false, null,
                    ApiResultConstants.MESSAGE(ApiResultConstants.CODE.CLIENT_ERROR));
                return result;
            }
            var roleNameList = await _userManager.GetRolesAsync(user);
            var roleDTOList = new List<RoleDTO>();
            foreach (var roleName in roleNameList)
            {
                var role = await _roleManager.FindByNameAsync(roleName);
                var roleDTO = new RoleDTO()
                {
                    Id = role.Id,
                    Name = role.Name
                };
                roleDTOList.Add(roleDTO);
            }
            result.SetResult((int)ApiResultConstants.CODE.SUCCESS, true, roleDTOList,
                ApiResultConstants.MESSAGE(ApiResultConstants.CODE.SUCCESS));
            return result;
        }

        /// <summary>
        /// 
        /// R
        /// 
        /// Get Role Name - List
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<string>> GetRoleNameAsync(string userId)
        {
            var result = new List<string>();
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return result;
            }
            var roleNameList = await _userManager.GetRolesAsync(user);
            if (roleNameList != null)
            {
                result.AddRange(roleNameList);
            }
            return result;
        }

        /// <summary>
        /// 
        /// D
        /// 
        /// Delete User from Role
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ApiResult<bool>> RemoveUserFromRole(RemoveUserFromRoleRequest request)
        {
            var apiResult = new ApiResult<bool>(false);
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            var role = await _roleManager.FindByIdAsync(request.RoleId.ToString());
            if (user == null || role == null)
            {
                apiResult.SetResult((int)ApiResultConstants.CODE.ERROR, false, false,
                    ApiResultConstants.MESSAGE(ApiResultConstants.CODE.ERROR));
                return apiResult;
            }
            var removeResult = await _userManager.RemoveFromRoleAsync(user, role.Name);
            if (removeResult.Succeeded)
            {
                apiResult.SetResult((int)ApiResultConstants.CODE.SUCCESS, true, true,
                    ApiResultConstants.MESSAGE(ApiResultConstants.CODE.SUCCESS));
                return apiResult;
            }
            else
            {
                apiResult.SetResult((int)ApiResultConstants.CODE.ERROR, false, false,
                    ApiResultConstants.MESSAGE(ApiResultConstants.CODE.ERROR));
                return apiResult;
            }
        }



        ///
        ///     PERMISISON
        /// 

        /// <summary>
        /// 
        /// R
        /// 
        /// User - HAS PERMISSION
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="name"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        // public async Task<bool> CheckPermissionAsync(string userId, string name, string action)
        // {
        //     var user = await _userManager.FindByIdAsync(userId);
        //     var roleNames = await _userManager.GetRolesAsync(user);
        //     var roleList = new List<ApplicationRole>();
        //     foreach (var roleName in roleNames)
        //     {
        //         var role = await _roleManager.FindByNameAsync(roleName);
        //         roleList.Add(role);
        //     }
        //     // var permissionList = _roleService.GetPermissions(roles);
        //     // var aPermisison = (await _unitOfWork.PermissionRepository.FindAsync(
        //     //     x => x.Name == name && x.Action == action))[0];
        //     // return permissions.Contains(aPermisison);
        // }



        ///
        ///     PRIVATE METHOD
        ///
        private UserDTO GetUserDTO_Full(ApplicationUser user)
        {
            return new UserDTO()
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName
            };
        }
        private UserDTO GetUserDTO(ApplicationUser user)
        {
            return new UserDTO()
            {
                UserName = user.UserName
            };
        }
    }
}