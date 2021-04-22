using System;
using System.Threading.Tasks;
using vigalileo.DTOs.Common;
using vigalileo.DTOs.System.Users;

namespace vigalileo.Services.System.Users
{
    public interface IUserService
    {
        Task<ApiResult<bool>> RegisterAsync(RegisterRequest request);
        Task<ApiResult<string>> LoginAsync(LoginRequest request);

        Task<ApiResult<UserDTO>> GetById(Guid userId);
    }
}