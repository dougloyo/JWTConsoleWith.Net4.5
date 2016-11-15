using System;
using System.Security.Claims;

namespace JWTnet4._5
{
    public interface IJwtProvider
    {
        string GetToken(string user, DateTime? expires);
        bool ValidateToken(string token);
        ClaimsPrincipal GetClaimsPrincipal(string token);
    }
}
