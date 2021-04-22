using System;
using Microsoft.AspNetCore.Mvc;
using vigalileo.Services.System.Users;
using vigalileo.DTOs.System.Users;
using System.Threading.Tasks;
using vigalileo.DTOs.Common;
using vigalileo.Utilities.Constants;
using vigalileo.Utilities.UriUtils;
using Microsoft.Extensions.Primitives;
using System.Linq;
using vigalileo.BackendApi.Extensions;

namespace vigalileo.BackendApi.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet(UriConstants.API_USERS_ID_GET_PATH)]
        public async Task<IActionResult> Read(Guid userId)
        {
            var result = new ApiResult<UserDTO>(new UserDTO());

            if (!ModelState.IsValid)
            {
                var validatorResult = new ApiResult<Guid>(new Guid());
                validatorResult.SetResult((int)ApiResultConstants.CODE.CLIENT_ERROR, false, userId, ModelState.GetMessages());
                return Ok(validatorResult);
            }

            result = await _userService.GetById(userId);
            return Ok(result);
        }

        [HttpPost(UriConstants.API_USERS_REGISTER_POST_PATH)]
        public async Task<IActionResult> Register([FromBody] RegisterRequest req)
        {
            var result = new ApiResult<bool>(false);
            if (StringValues.IsNullOrEmpty(HttpContext.Request.Headers["Authorization"]) == false)
            {
                result.SetResult((int)ApiResultConstants.CODE.CLIENT_ERROR, false, false, ApiResultConstants.MESSAGE(ApiResultConstants.CODE.CLIENT_ERROR), "hahaha");
                return Ok(result);
            }

            if (!ModelState.IsValid)
            {
                var validatorResult = new ApiResult<RegisterRequest>(new RegisterRequest());
                validatorResult.SetResult((int)ApiResultConstants.CODE.CLIENT_ERROR, false, req, ModelState.GetMessages());
                return Ok(validatorResult);
            }

            result = await _userService.RegisterAsync(req);
            return Ok(result);
        }

        [HttpPost(UriConstants.API_USERS_LOGIN_POST_PATH)]
        public async Task<IActionResult> Login([FromBody] LoginRequest req)
        {
            var result = new ApiResult<string>("");

            ///
            /// TODO: 
            /// 1. Neu co Author
            /// 1.a. Dung JWT
            /// 1.b. Sai JWT
            ///  
            /// /// // if (StringValues.IsNullOrEmpty(HttpContext.Request.Headers["Authorization"]) == false)
            // {
            //     result.SetResult((int)ApiResultConstants.CODE.CLIENT_ERROR, false, false, ApiResultConstants.MESSAGE(ApiResultConstants.CODE.CLIENT_ERROR), "hahaha");
            //     return Ok(result);
            // }

            if (!ModelState.IsValid)
            {
                var validatorResult = new ApiResult<LoginRequest>(new LoginRequest());
                validatorResult.SetResult((int)ApiResultConstants.CODE.CLIENT_ERROR, false, req, ModelState.GetMessages());
                return Ok(validatorResult);
            }

            result = await _userService.LoginAsync(req);
            return Ok(result);
        }
    }
}