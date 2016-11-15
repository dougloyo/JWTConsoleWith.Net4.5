using System.Collections.Generic;
using System.Security.Claims;

namespace JWTnet4._5
{
    public class TestClaimsIdentityProvider : IClaimsIdentityProvider
    {
        public ClaimsIdentity GetClaimsIdentity(string userId)
        {
            var claimsIdentity = new ClaimsIdentity();

            // TODO: Got to database.
            // Here, should look up an identity for the user which was authenticated.
            // For now, just creating a simple generic identity.
            var claims = new List<Claim>
            {
                new Claim("sub", userId),
                new Claim(ClaimTypes.Name, "Doug Loyo"),
                new Claim(ClaimTypes.Email, "doug@loyo.com"),
                new Claim(ClaimTypes.Role, "Chingon"),
            };

            claimsIdentity.AddClaims(claims);

            return claimsIdentity;
        }
    }
}