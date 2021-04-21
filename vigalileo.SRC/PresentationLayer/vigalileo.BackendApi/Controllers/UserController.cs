using Microsoft.AspNetCore.Mvc;
using vigalileo.Services.System.Users;
using vigalileo.DTOs.System.Users;
using System.Threading.Tasks;
using vigalileo.DTOs.Common;
using vigalileo.Utilities.Constants;
using vigalileo.Utilities.UriUtils;

namespace vigalileo.BackendApi.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost(UriConstants.API_USERS_REGISTER)]
        public async Task<IActionResult> Register(RegisterRequest req)
        {
            var result = new ApiResult<bool>(false);
            if (HttpContext.Request.Headers["Authorization"].ToString() != null)
            {
                result.SetResult((int) ApiResultConstants.CODE.CLIENT_ERROR, false, false, ApiResultConstants.MESSAGE(ApiResultConstants.CODE.CLIENT_ERROR)); 
                return Ok(result);
            }
            result = await _userService.RegisterAsync(req);
            return Ok(result);
        }
    }
}