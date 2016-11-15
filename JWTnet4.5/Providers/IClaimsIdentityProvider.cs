using System.Security.Claims;

namespace JWTnet4._5
{
    public interface IClaimsIdentityProvider
    {
        /// <summary>
        /// Gets a Claims Identity based off of a userId.
        /// </summary>
        /// <param name="userId">The user's unique identifier</param>
        /// <returns type="ClaimsIdentity">ClaimsIdentity</returns>
        ClaimsIdentity GetClaimsIdentity(string userId);
    }
}
