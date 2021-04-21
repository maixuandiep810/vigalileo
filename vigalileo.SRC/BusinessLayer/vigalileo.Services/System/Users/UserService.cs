using System;
using vigalileo.DTOs.System.Users;
using vigalileo.DTOs.Common;
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

namespace vigalileo.Services.System.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IConfiguration _configuration;

        public UserService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        /// <summary>
        /// REGISTER A ACCOUNT
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ApiResult<bool>> RegisterAsync(RegisterRequest request)
        {
            var apiResult = new ApiResult<bool>(false);
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user != null || await _userManager.FindByEmailAsync(request.Email) != null)
            {
                apiResult.SetResult(
                    (int)ApiResultConstants.CODE.USERNAME_PASSWORD_EXISTS_E,
                    false,
                    false,
                    ApiResultConstants.MESSAGE(ApiResultConstants.CODE.USERNAME_PASSWORD_EXISTS_E));
                return apiResult;
            }

            user = new ApplicationUser()
            {
                Email = request.Email,
                UserName = request.UserName,
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                apiResult.SetResult(
                    (int)ApiResultConstants.CODE.USERNAME_PASSWORD_EXISTS_E,
                    true,
                    true,
                    ApiResultConstants.MESSAGE(ApiResultConstants.CODE.USERNAME_PASSWORD_EXISTS_E));
                return apiResult;
            }
            return apiResult;
        }


        public async Task<ApiResult<string>> Authencate(LoginRequest request)
        {
            var apiResult = new ApiResult<string>("");
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null || (await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true)).Succeeded)
            {
                apiResult.SetResult(
                    (int)ApiResultConstants.CODE.USERNAME_PASSWORD_EXISTS_E,
                    false,
                    "",
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

            apiResult.SetResult(
                (int)ApiResultConstants.CODE.SUCCESS,
                true,
                jwtToken,
                ApiResultConstants.MESSAGE(ApiResultConstants.CODE.SUCCESS));
            return apiResult;
        }
    }
}