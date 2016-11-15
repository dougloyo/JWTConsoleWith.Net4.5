using System;
using System.IdentityModel.Protocols.WSTrust;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using JWTnet4._5.Providers;

namespace JWTnet4._5
{
    public class JwtProvider : IJwtProvider
    {
        private readonly IClaimsIdentityProvider _claimsIdentityProvider;
        private readonly ISigningCredentialsProvider _signingCredentialsProvider;
        private readonly IApplicationSettingsProvider _applicationSettingsProvider;

        public JwtProvider(IClaimsIdentityProvider claimsIdentityProvider, ISigningCredentialsProvider signingCredentialsProvider, IApplicationSettingsProvider applicationSettingsProvider)
        {
            _claimsIdentityProvider = claimsIdentityProvider;
            _signingCredentialsProvider = signingCredentialsProvider;
            _applicationSettingsProvider = applicationSettingsProvider;
        }

        public string GetToken(string user, DateTime? expires)
        {
            var handler = new JwtSecurityTokenHandler();

            var identity = _claimsIdentityProvider.GetClaimsIdentity("abc123");

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                // Issuer
                TokenIssuerName = _applicationSettingsProvider.GetValue("JWT.Issuer"),

                //Audience = tokenOptions.Audience,
                AppliesToAddress = _applicationSettingsProvider.GetValue("JWT.Audience"), // Audience
                SigningCredentials = _signingCredentialsProvider.GetSigningCredentials(),
                Subject = identity,
                //Expires = expires
                Lifetime = new Lifetime(DateTime.Now, expires)

            };

            var securityToken = handler.CreateToken(securityTokenDescriptor);

            return handler.WriteToken(securityToken);
        }

        public bool ValidateToken(string token)
        {
            // For the Validation of the Token the Client system should have the paramters to validate.
            try
            {
                var handler = new JwtSecurityTokenHandler();
                SecurityToken securityToken;
                handler.ValidateToken(token, GetTokenValidationParameters(), out securityToken);

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public ClaimsPrincipal GetClaimsPrincipal(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;

            return handler.ValidateToken(token, GetTokenValidationParameters(), out securityToken);
        }

        private TokenValidationParameters GetTokenValidationParameters()
        {
            // The valid Issuer that the client app trusts
            var validIssuer = _applicationSettingsProvider.GetValue("JWT.Client.Issuer");
            var validAudience = _applicationSettingsProvider.GetValue("JWT.Client.Audience");

            return new TokenValidationParameters
            {
                ValidIssuer = validIssuer,
                ValidAudience = validAudience,
                IssuerSigningKey = _signingCredentialsProvider.GetSigningCredentials().SigningKey
            };
        }
    }
}