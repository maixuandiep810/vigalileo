using System.Security.Claims;

namespace vigalileo.Services.System.Auth
{
    public interface IJWTService
    {
        ClaimsPrincipal ValidateToken(string jwtToken);
    }
}